namespace Projet2.Models
{
    public class DashboardViewModel
    {
        public WeatherResponse Weather { get; set; } = new WeatherResponse();
        public MovieResponse Movies { get; set; } = new MovieResponse();
        public string ErrorMessage { get; set; } = "";
    }
}