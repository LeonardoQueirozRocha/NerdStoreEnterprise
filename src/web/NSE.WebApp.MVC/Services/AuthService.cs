using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models.Error;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);

            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> LoginAsync(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identity/login", loginContent);

            if (!HandleResponseErrors(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
                };
            }

            return await DeserializeResponseObject<UserResponseLogin>(response);
        }

        public async Task<UserResponseLogin> RegisterAsync(UserRegistration userRegistration)
        {
            var registerContent = GetContent(userRegistration);

            var response = await _httpClient.PostAsync("/api/identity/new-account", registerContent);

            if (!HandleResponseErrors(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeResponseObject<ResponseResult>(response)
                };
            }

            return await DeserializeResponseObject<UserResponseLogin>(response);
        }
    }
}
