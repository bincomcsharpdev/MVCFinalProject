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
            _httpClient.BaseAddress = new Uri("https://yourapiurl.com/api/Auth/");
        }

        public async Task<bool> RegisterAsync(RegisterRequestDto request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("register", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<string?> LoginAsync(LoginRequestDto request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", content);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            return result?["Token"];
        }
    }
}
