using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecomendation
{
    public enum Genres
    {
        thriller, detective, documentary, horror, cartoon, comedy, drama, melodrama,
        crime, mystic, musical, scientific, adventure, fiction, fantasy
    };

    class Movie
    {
        public Movie(string title, string director, Genres genre, double rating)
        {
            Title = title;
            Director = director;
            Genre = genre;
            Rating = rating;
        }

        public string Title { get; private set; }
        public string Director { get; private set; }
        public Genres Genre { get; private set; }
        public double Rating { get; private set; }
    }
}
