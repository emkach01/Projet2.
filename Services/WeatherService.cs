using Projet2.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponse> GetWeather(string city)
    {
        var apiKey = "0886ba7d95112522977a6172d8b10d24";
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        try
        {
            return await _httpClient.GetFromJsonAsync<WeatherResponse>(url)
                   ?? new WeatherResponse();
        }
        catch
        {
            return new WeatherResponse();
        }
    }
}