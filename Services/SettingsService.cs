using MealPlanner.Models;
using System.Net.Http.Json;

namespace MealPlanner.Services
{
    public class SettingsService
    {
        private readonly HttpClient _http;

        public SettingsService(HttpClient http, IConfiguration config)
        {
            _http = http;
        }

        public async Task<SettingsModel> GetSettingsAsync()
        {
            return await _http.GetFromJsonAsync<SettingsModel>("settings");
        }

        public async Task<HttpResponseMessage> UpdateSettingsAsync(SettingsModel settings)
        {
            return await _http.PutAsJsonAsync("settings", settings);
        }
    }
}
