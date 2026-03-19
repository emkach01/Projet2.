using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet2.Models
{
    public class WeatherResponse
    {
        public string? Name { get; set; }
        public MainInfo? Main { get; set; }
        public List<WeatherInfo>? Weather { get; set; }
        public WindInfo? Wind { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        public string? Description { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}