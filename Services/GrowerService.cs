using System.Net.Http.Json;
using GNUCannabis.Models;

namespace GNUCannabis.Services
{
    public class GrowerService
    {
        private readonly HttpClient _http;

        public GrowerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Grower>> GetGrowersAsync()
        {
            try
            {
                var response = await _http.GetAsync("Usuarios");
                response.EnsureSuccessStatusCode();

                var growers = await response.Content.ReadFromJsonAsync<List<Grower>>();
                return growers ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching Growers: {e.Message}");
                return [];
            }
        }

        public async Task<Grower> GetGrowerByIdAsync(int id)
        {
            try
            {
                var response = await _http.GetAsync($"Usuarios/{id}");
            response.EnsureSuccessStatusCode();

            var Grower = await response.Content.ReadFromJsonAsync<Grower>();
            return Grower ?? new Grower();
            }
            catch (Exception e)
            {
            Console.WriteLine($"Error fetching Grower By Id: {e.Message}");
                return new Grower();
            }
        }
    }
}