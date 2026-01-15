using NasaApodGallery.Models;
using System.Net.Http;
using System.Text.Json;

namespace NasaApodGallery.Services
{
    public class NasaApodService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NasaApodService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["NASA:ApiKey"];
        }

        public async Task<List<ApodDto>> GetApodRange(string startDate, string endDate)
        {
            string url = $"https://api.nasa.gov/planetary/apod?start_date={startDate}&end_date={endDate}&api_key={_apiKey}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<ApodDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
