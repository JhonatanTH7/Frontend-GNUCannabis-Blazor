using GNUCannabis.Models;
using System.Net.Http.Json;

namespace GNUCannabis.Services
{
    public class CropService
    {
        private readonly HttpClient _http;

        public CropService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Crop>> GetCropsAsync()
        {
            try
            {
                var response = await _http.GetAsync("Cultivos");
                response.EnsureSuccessStatusCode();

                var crops = await response.Content.ReadFromJsonAsync<List<Crop>>();
                return crops ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Crops: {e.Message}");
                return [];
            }
        }

        public async Task<Crop> GetCropByIdAsync(int id)
        {
            try
            {
                var response = await _http.GetAsync($"Cultivos/{id}");
                response.EnsureSuccessStatusCode();

                var crop = await response.Content.ReadFromJsonAsync<Crop>();
                return crop ?? new Crop();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Crop By Id: {e.Message}");
                return new Crop();
            }
        }
    }
}