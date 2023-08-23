using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using NSE.Core.Messages.Integrations;
using NSE.Identity.API.Data;
using NSE.Identity.API.Extensions;
using NSE.Identity.API.Models;
using NSE.Identity.API.Services.Base;
using NSE.Identity.API.Services.Interfaces;
using NSE.MessageBus.Interfaces;
using NSE.WebApi.Core.User.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.Identity.API.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppTokenSettings _appTokenSettings;
    private readonly ApplicationDbContext _context;
    private readonly IAspNetUser _aspNetUser;
    private readonly IJwtService _jwtService;
    private readonly IMessageBus _bus;

    public AuthService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppTokenSettings> appTokenSettings,
        ApplicationDbContext context,
        IAspNetUser aspNetUser,
        IJwtService jwtService,
        IMessageBus bus)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _appTokenSettings = appTokenSettings.Value;
        _context = context;
        _aspNetUser = aspNetUser;
        _jwtService = jwtService;
        _bus = bus;
    }

    public async Task<UserResponseLogin> GenerateJwtAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var claims = await _userManager.GetClaimsAsync(user);
        var identityClaims = await GetUserClaimsAsync(claims, user);
        var encodedToken = await EncodeToken(identityClaims);
        var refreshToken = await GenerateRefreshTokenAsync(email);

        return GetTokenResponse(encodedToken, user, claims, refreshToken);
    }

    public async Task<ValidationResult> CreateUserAsync(UserRegistration userRegistration)
    {
        var user = new IdentityUser
        {
            UserName = userRegistration.Email,
            Email = userRegistration.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegistration.Password);

        if (!result.Succeeded)
        {
            AddErrors(result.Errors.Select(e => e.Description).ToList());
            return GetValidation();
        }

        var resultCustomer = await CustomerRegistrationAsync(userRegistration);

        if (!resultCustomer.ValidationResult.IsValid)
        {
            await _userManager.DeleteAsync(user);
            return resultCustomer.ValidationResult;
        }

        return GetValidation();
    }

    public async Task<ValidationResult> LoginAsync(UserLogin userLogin)
    {
        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.Succeeded) return GetValidation();

        if (result.IsLockedOut)
        {
            AddError("Usuário temporariamente bloqueado por tentativas inválidas");
            return GetValidation();
        }

        AddError("Usuário ou Senha incorretos");
        return GetValidation();
    }

    public async Task<RefreshToken> GetRefreshTokenAsync(Guid token)
    {
        var refreshToken = await _context.RefreshTokens
            .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Token == token);

        var isTokenValid = refreshToken != null && refreshToken.ExpirationDate.ToLocalTime() > DateTime.Now;

        return isTokenValid ? refreshToken : null;
    }

    private async Task<ClaimsIdentity> GetUserClaimsAsync(ICollection<Claim> claims, IdentityUser user)
    {
        var userRoles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

        foreach (var userRole in userRoles) claims.Add(new Claim("role", userRole));

        var identityClaims = new ClaimsIdentity();
        identityClaims.AddClaims(claims);

        return identityClaims;
    }

    private async Task<string> EncodeToken(ClaimsIdentity identityClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var currentIssuer = $"{_aspNetUser.GetHttpContext().Request.Scheme}://{_aspNetUser.GetHttpContext().Request.Host}";
        var key = await _jwtService.GetCurrentSigningCredentials();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = currentIssuer,
            Subject = identityClaims,
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = key
        });

        return tokenHandler.WriteToken(token);
    }

    private static UserResponseLogin GetTokenResponse(
        string encodedToken,
        IdentityUser user,
        IEnumerable<Claim> claims,
        RefreshToken refreshToken)
    {
        var userResponseLogin = new UserResponseLogin
        {
            AccessToken = encodedToken,
            RefreshToken = refreshToken.Token,
            ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
            UserToken = new UserToken
            {
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
            }
        };

        return userResponseLogin;
    }

    private static long ToUnixEpochDate(DateTime date)
    => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    private async Task<ResponseMessage> CustomerRegistrationAsync(UserRegistration userRegistration)
    {
        var user = await _userManager.FindByEmailAsync(userRegistration.Email);
        var registeredUser = new RegisteredUserIntegrationEvent(Guid.Parse(user.Id), userRegistration.Name, userRegistration.Email, userRegistration.Cpf);

        try
        {
            return await _bus.RequestAsync<RegisteredUserIntegrationEvent, ResponseMessage>(registeredUser);
        }
        catch
        {
            await _userManager.DeleteAsync(user);
            throw;
        }
    }

    private async Task<RefreshToken> GenerateRefreshTokenAsync(string email)
    {
        var refreshToken = new RefreshToken
        {
            Username = email,
            ExpirationDate = DateTime.UtcNow.AddHours(_appTokenSettings.RefreshTokenExpiration),
        };

        _context.RefreshTokens.RemoveRange(_context.RefreshTokens.Where(u => u.Username == email));

        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();

        return refreshToken;
    }
}
