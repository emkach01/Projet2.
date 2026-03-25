using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

public class HomeController : Controller
{
    private readonly WeatherService _weatherService;
    private readonly MovieService _movieService;
    private readonly IMemoryCache _cache;

    public HomeController(WeatherService weatherService, MovieService movieService, IMemoryCache cache)
    {
        _weatherService = weatherService;
        _movieService = movieService;
        _cache = cache;
    }

    public async Task<IActionResult> Index()
    {
        // Cache météo : 5 minutes (la météo change lentement)
        var weather = await _cache.GetOrCreateAsync("weather_data", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return await _weatherService.GetWeather("Montreal");
        });

        // Cache films : 30 minutes (les films populaires changent rarement)
        var movies = await _cache.GetOrCreateAsync("movies_data", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return await _movieService.GetPopularMovies();
        });

        ViewBag.Weather = weather;
        ViewBag.Movies = movies;

        return View();
    }
}