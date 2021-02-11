namespace MovieRatings.Web.ViewModels.Movies
{
    using System.Collections.Generic;

    public class MoviesListViewModel
    {
        public IEnumerable<MovieInListViewModel> Movies { get; set; }

        public int PageNumber { get; set; }
    }
}
