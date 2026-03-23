using System.Collections.Generic;

namespace Projet2.Models
{
    public class MovieResponse
    {
        public List<Movie> Results { get; set; } = new List<Movie>();
    }

    public class Movie
    {
        public string Title { get; set; } = "";
    }
}