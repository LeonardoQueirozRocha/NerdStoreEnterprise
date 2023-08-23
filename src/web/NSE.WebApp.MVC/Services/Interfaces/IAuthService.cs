using NSE.WebApp.MVC.Models.Identity;

namespace NSE.WebApp.MVC.Services.Interfaces;

public interface IAuthService
{
    Task<UserResponseLogin> LoginAsync(UserLogin userLogin);
    Task<UserResponseLogin> RegisterAsync(UserRegistration userRegistration);
    Task<UserResponseLogin> UseRefreshTokenAsync(string refreshToken);
    Task SignInAsync(UserResponseLogin response);
    Task LogoutAsync();
    bool IsTokenExpired();
    Task<bool> IsRefreshTokenValid();
}