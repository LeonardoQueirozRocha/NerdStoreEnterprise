using NSE.WebApp.MVC.Models.Identity;

namespace NSE.WebApp.MVC.Services
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(UserLogin userLogin);
        Task<string> RegisterAsync(UserRegistration userRegistration);
    }
}
