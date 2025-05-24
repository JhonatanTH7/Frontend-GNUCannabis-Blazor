using System.Net.Http.Json;
using GNUCannabis.Models;

namespace GNUCannabis.Services
{
    public class PlantService
    {
        private readonly HttpClient _http;

        public PlantService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Plant>> GetPlantsAsync()
        {
            try
            {
                var response = await _http.GetAsync("Plantas");
                response.EnsureSuccessStatusCode();

                var Plants = await response.Content.ReadFromJsonAsync<List<Plant>>();
                return Plants ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Plants: {e.Message}");
                return [];
            }
        }
        
        public async Task<Plant> GetPlantByIdAsync(int id)
        {
            try
            {
                var response = await _http.GetAsync($"Plantas/{id}");
                response.EnsureSuccessStatusCode();

                var Plant = await response.Content.ReadFromJsonAsync<Plant>();
                return Plant ?? new Plant();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Plant By Id: {e.Message}");
                return new Plant();
            }
        }

        public async Task<List<Plant>> GetGPlantsByCropId(int id)
        {
            try
            {
                var response = await _http.GetAsync($"Plantas/Cultivo/{id}");
                response.EnsureSuccessStatusCode();

                var Plants = await response.Content.ReadFromJsonAsync<List<Plant>>();
                return Plants ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Plants by Crop: {e.Message}");
                return [];
            }
        }
    }
}