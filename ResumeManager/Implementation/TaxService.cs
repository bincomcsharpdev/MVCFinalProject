using System.Text.Json;
using System.Text;
using ResumeManager.Models;

namespace ResumeManager.Implementation
{
    public class TaxService
    {
        private readonly HttpClient _httpClient;

        public TaxService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://anthoniaresumemangerwebapi-f0ccb0argmfgdzgt.canadacentral-01.azurewebsites.net/api/Tax/");
        }

        public async Task<Anthonia_PAYEDto?> CalculatePAYEAsync(Anthonia_PAYEDto model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("calculate-paye", content);
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Anthonia_PAYEDto>(json);
        }
    }
}
