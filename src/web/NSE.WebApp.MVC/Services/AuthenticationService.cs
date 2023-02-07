using NSE.WebApp.MVC.Models.Identity;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(UserLogin userLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(userLogin), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44350/api/identity/login", loginContent);

            var test = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> RegisterAsync(UserRegistration userRegistration)
        {
            var registerContent = new StringContent(JsonSerializer.Serialize(userRegistration), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44350/api/identity/new-account", registerContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
