using NSE.WebApp.MVC.Models.Identity;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<UserResponseLogin> LoginAsync(UserLogin userLogin);
        Task<UserResponseLogin> RegisterAsync(UserRegistration userRegistration);
    }
}
