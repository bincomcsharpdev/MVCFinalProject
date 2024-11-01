using System.Text.Json;
using System.Text;
using ResumeManager.Models;

namespace ResumeManager.Implementation
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://anthoniaresumemangerwebapi-f0ccb0argmfgdzgt.canadacentral-01.azurewebsites.net/api/Auth/");
        }

        public async Task<bool> RegisterAsync(AccountViewModel request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request.RegisterRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("register", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<string?> LoginAsync(AccountViewModel request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request.LoginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", content);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return result?["token"];
        }
    }
}
