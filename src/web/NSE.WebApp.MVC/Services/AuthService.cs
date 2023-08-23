using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApi.Core.User.Interfaces;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.WebApp.MVC.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IAuthenticationService _authenticationService;
    private readonly IAspNetUser _user;

    public AuthService(
        HttpClient httpClient,
        IAuthenticationService authenticationService,
        IAspNetUser user,
        IOptions<AppSettings> settings)
    {
        httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);
        _httpClient = httpClient;
        _authenticationService = authenticationService;
        _user = user;
    }

    public async Task<UserResponseLogin> LoginAsync(UserLogin userLogin)
    {
        var loginContent = GetContent(userLogin);
        var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

        if (!HandleResponseErrors(response))
            return await HandleResponseResultAsync(response);

        return await DeserializeResponseObject<UserResponseLogin>(response);
    }

    public async Task<UserResponseLogin> RegisterAsync(UserRegistration userRegistration)
    {
        var registerContent = GetContent(userRegistration);

        var response = await _httpClient.PostAsync("/api/identity/new-account", registerContent);

        if (!HandleResponseErrors(response))
            return await HandleResponseResultAsync(response);

        return await DeserializeResponseObject<UserResponseLogin>(response);
    }

    public async Task<UserResponseLogin> UseRefreshTokenAsync(string refreshToken)
    {
        var refreshTokenContent = GetContent(refreshToken);
        var response = await _httpClient.PostAsync("/api/identity/refresh-token", refreshTokenContent);

        if (!HandleResponseErrors(response))
            return await HandleResponseResultAsync(response);

        return await DeserializeResponseObject<UserResponseLogin>(response);
    }

    public async Task SignInAsync(UserResponseLogin response)
    {
        var claimsIdentity = ConfigureClaimsIdentity(response);
        var authenticationProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(8),
            IsPersistent = true,
        };

        await _authenticationService.SignInAsync(
            _user.GetHttpContext(),
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authenticationProperties);
    }

    public async Task LogoutAsync()
    {
        await _authenticationService.SignOutAsync(
            _user.GetHttpContext(),
            CookieAuthenticationDefaults.AuthenticationScheme,
            null);
    }

    public bool IsTokenExpired()
    {
        var jwt = _user.GetUserToken();

        if (jwt is null) return false;

        var token = GetFormattedToken(jwt);

        return token.ValidTo.ToLocalTime() < DateTime.Now;
    }

    public async Task<bool> IsRefreshTokenValid()
    {
        var response = await UseRefreshTokenAsync(_user.GetUserRefreshToken());

        if (response.AccessToken != null && response.ResponseResult == null)
        {
            await SignInAsync(response);
            return true;
        }

        return false;
    }

    private static JwtSecurityToken GetFormattedToken(string jwtToken)
    {
        return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
    }

    private static ClaimsIdentity ConfigureClaimsIdentity(UserResponseLogin response)
    {
        var token = GetFormattedToken(response.AccessToken);
        var claims = new List<Claim>
        {
            new Claim("JWT", response.AccessToken),
            new Claim("RefreshToken", response.RefreshToken)
        };

        claims.AddRange(token.Claims);

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        return claimsIdentity;
    }

    private async Task<UserResponseLogin> HandleResponseResultAsync(HttpResponseMessage response)
    {
        var userResponseLogin = new UserResponseLogin
        {
            ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
        };

        return userResponseLogin;
    }
}