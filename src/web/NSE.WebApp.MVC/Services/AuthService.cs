using NSE.WebApp.MVC.Models.Error;
using NSE.WebApp.MVC.Models.Identity;
using NSE.WebApp.MVC.Services.Base;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> LoginAsync(UserLogin userLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44350/api/identity/login", loginContent);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            if (!HandleResponseErrors(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UserResponseLogin> RegisterAsync(UserRegistration userRegistration)
        {
            var registerContent = new StringContent(JsonSerializer.Serialize(userRegistration), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44350/api/identity/new-account", registerContent);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            if (!HandleResponseErrors(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = JsonSerializer.Deserialize<ResponseResult>(await response.Content.ReadAsStringAsync(), options)
                };
            }

            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
