using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Projet2.Models
{
    public class MovieResponse
    {
        [JsonPropertyName("results")]
        public List<Movie>? Results { get; set; }
    }

    public class Movie
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        // view uses PosterPath
        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }

        // view uses VoteAverage
        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        // view uses ReleaseDate (keep as string to display directly)
        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }
    }
}