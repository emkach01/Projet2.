using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Projet2.Models;

namespace Projet2_M.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MovieService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<MovieResponse> GetPopularMovies()
        {
            string? apiKey = _configuration["ApiKeys:Tmdb"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new Exception("La clé API TMDB est introuvable.");
            }

            string url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page=1";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erreur lors de l'appel à l'API TMDB.");
            }

            MovieResponse? movies = await response.Content.ReadFromJsonAsync<MovieResponse>();

            return movies ?? new MovieResponse();
        }
    }
}