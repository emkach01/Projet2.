using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Projet2.Models;

namespace Projet2_M.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherResponse> GetWeather(string city)
        {
            string? apiKey = _configuration["ApiKeys:OpenWeather"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("La clé API OpenWeather est introuvable.");
            }

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erreur lors de l'appel à l'API OpenWeather.");
            }

            WeatherResponse? weather = await response.Content.ReadFromJsonAsync<WeatherResponse>();

            return weather ?? new WeatherResponse();
        }
    }
}