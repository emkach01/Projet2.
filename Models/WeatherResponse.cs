using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Projet2.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("main")]
        public MainInfo? Main { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherInfo>? Weather { get; set; }

        [JsonPropertyName("wind")]
        public WindInfo? Wind { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        // On conserve le nom utilisé dans la vue (Feels_Like) et on mappe le JSON "feels_like"
        [JsonPropertyName("feels_like")]
        public double Feels_Like { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }

    public class WindInfo
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }
}