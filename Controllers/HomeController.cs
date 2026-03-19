using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    private readonly WeatherService _weatherService;
    private readonly MovieService _movieService;

    public HomeController(WeatherService weatherService, MovieService movieService)
    {
        _weatherService = weatherService;
        _movieService = movieService;
    }

    public async Task<IActionResult> Index()
    {
        var weather = await _weatherService.GetWeather("Montreal");
        var movies = await _movieService.GetPopularMovies();

        ViewBag.Weather = weather;
        ViewBag.Movies = movies;

        return View();
    }
}