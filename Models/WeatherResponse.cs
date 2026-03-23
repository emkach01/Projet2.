namespace Projet2.Models
{
    public class WeatherResponse
    {
        public string Name { get; set; } = "";
        public MainInfo Main { get; set; } = new MainInfo();
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
    }
}