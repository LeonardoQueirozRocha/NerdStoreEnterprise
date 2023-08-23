using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;
using NSE.Identity.API.Services.Interfaces;
using NSE.WebApi.Core.Controllers;

namespace NSE.Identity.API.Controllers;

[Route("api/identity")]
public class AuthController : MainController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("new-account")]
    public async Task<ActionResult> Register(UserRegistration userRegistration)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _authService.CreateUserAsync(userRegistration);

        if (!result.IsValid) return CustomResponse(result);

        return CustomResponse(await _authService.GenerateJwtAsync(userRegistration.Email));
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLogin userLogin)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        var result = await _authService.LoginAsync(userLogin);

        if (!result.IsValid) return CustomResponse(result);

        return CustomResponse(await _authService.GenerateJwtAsync(userLogin.Email));
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult> RefreshToken([FromBody] string refreshToken)
    {
        if (string.IsNullOrEmpty(refreshToken))
        {
            AddProcessingError("Refresh Token inválido");
            return CustomResponse();
        }

        var token = await _authService.GetRefreshTokenAsync(Guid.Parse(refreshToken));

        if (token == null)
        {
            AddProcessingError("Refresh Token expirado");
            return CustomResponse();
        }

        return CustomResponse(await _authService.GenerateJwtAsync(token.Username));
    }
}