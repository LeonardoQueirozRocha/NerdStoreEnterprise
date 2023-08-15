using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using NSE.Core.Messages.Integrations;
using NSE.Identity.API.Models;
using NSE.MessageBus.Interfaces;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.Identity;
using NSE.WebApi.Core.User.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NSE.Identity.API.Controllers;

[Route("api/identity")]
public class AuthController : MainController
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings;
    private readonly IMessageBus _bus;
    private readonly IAspNetUser _aspNetUser;
    private readonly IJwtService _jwtService;

    public AuthController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppSettings> appSettings,
        IMessageBus bus,
        IAspNetUser aspNetUser,
        IJwtService jwtService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _appSettings = appSettings.Value;
        _bus = bus;
        _aspNetUser = aspNetUser;
        _jwtService = jwtService;
    }

    [HttpPost("new-account")]
    public async Task<ActionResult> Register(UserRegistration userRegistration)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var user = new IdentityUser
        {
            UserName = userRegistration.Email,
            Email = userRegistration.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, userRegistration.Password);

        if (result.Succeeded)
        {
            var resultCustomer = await CustomerRegistrationAsync(userRegistration);

            if (!resultCustomer.ValidationResult.IsValid)
            {
                await _userManager.DeleteAsync(user);
                return CustomResponse(resultCustomer.ValidationResult);
            }

            return CustomResponse(await GenerateJwtAsync(userRegistration.Email));
        }

        foreach (var error in result.Errors) AddProcessingError(error.Description);

        return CustomResponse();
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLogin userLogin)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

        if (result.Succeeded) return CustomResponse(await GenerateJwtAsync(userLogin.Email));

        if (result.IsLockedOut)
        {
            AddProcessingError("Usuário temporariamente bloqueado por tentativas inválidas");
            return CustomResponse();
        }

        AddProcessingError("Usuário ou Senha incorretos");
        return CustomResponse();
    }

    private async Task<UserResponseLogin> GenerateJwtAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var claims = await _userManager.GetClaimsAsync(user);
        var identityClaims = await GetUserClaimsAsync(claims, user);
        var encodedToken = await EncodeToken(identityClaims);

        return GetTokenResponse(encodedToken, user, claims);
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

    private UserResponseLogin GetTokenResponse(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
    {
        return new UserResponseLogin
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
            UserToken = new UserToken
            {
                Id = user.Id,
                Email = user.Email,
                Claims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
            }
        };
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
}