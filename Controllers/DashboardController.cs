using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Projet2.Models;
using Projet2_M.Services;

namespace Projet2_M.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WeatherService _weatherService;
        private readonly MovieService _movieService;
        private readonly IMemoryCache _memoryCache;

        public DashboardController(
            WeatherService weatherService,
            MovieService movieService,
            IMemoryCache memoryCache)
        {
            _weatherService = weatherService;
            _movieService = movieService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel vm = new DashboardViewModel();

            try
            {
                WeatherResponse? weather;
                MovieResponse? movies;

                if (!_memoryCache.TryGetValue("weather_montreal", out weather))
                {
                    weather = await _weatherService.GetWeather("Montreal");

                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                    _memoryCache.Set("weather_montreal", weather, cacheOptions);
                }

                if (!_memoryCache.TryGetValue("popular_movies", out movies))
                {
                    movies = await _movieService.GetPopularMovies();

                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                    _memoryCache.Set("popular_movies", movies, cacheOptions);
                }

                vm.Weather = weather ?? new WeatherResponse();
                vm.Movies = movies ?? new MovieResponse();
            }
            catch (Exception ex)
            {
                vm.ErrorMessage = ex.Message;
            }

            return View(vm);
        }
    }
}