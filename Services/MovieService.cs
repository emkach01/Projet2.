using System.Net.Http.Json;
using System.Threading.Tasks;
using Projet2.Models;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "8ed2fcb1031415c925b417420bc00f62";

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MovieResponse> GetPopularMovies()
    {
        var apiKey = "8ed2fcb1031415c925b417420bc00f62";
        var url = $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&language=en-US&page=1";

        try
        {
            return await _httpClient.GetFromJsonAsync<MovieResponse>(url)
                   ?? new MovieResponse();
        }
        catch
        {
            return new MovieResponse();
        }
    }
}