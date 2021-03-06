﻿namespace MovieRatings.Web.ViewModels.Movies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MovieRatings.Data.Models;
    using MovieRatings.Services.Mapping;

    public class EditMovieInputModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }
    }
}
