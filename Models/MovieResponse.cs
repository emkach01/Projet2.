using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace Projet2.Models
{
    public class MovieResponse
    {
        public List<Movie>? Results { get; set; }
    }

    public class Movie
    {
        public string? Title { get; set; }

        [JsonPropertyName("poster_path")]
        public string? PosterPath { get; set; }
    }
}