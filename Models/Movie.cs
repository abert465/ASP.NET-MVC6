using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieYearId { get; set; }
        public string MovieTitle { get; set; }
        public int ContentRatingId { get; set; }
        public string Star { get; set; }
        public string CoStar { get; set; }
        public string ThirdActor { get; set; }
        public string GenreId { get; set; }
        public int Budget { get; set; }
        public int Gross { get; set; }
        public int ImdbScoreId { get; set; }
        public int MovieLanguageId { get; set; }
        public int MovieCountryId { get; set; }
        public string MovieLink { get; set; }

        public virtual MovieYear MovieYear { get; set; }
        public virtual ContentRating ContentRating { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ImdbScore ImdbScore { get; set; }
        public virtual MovieLanguage MovieLanguage { get; set; }
        public virtual MovieCountry MovieCountry { get; set; }
    }

    public class MovieYear
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }

    public class ContentRating
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }

    public class ImdbScore
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }

    public class MovieLanguage
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }

    public class MovieCountry
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
