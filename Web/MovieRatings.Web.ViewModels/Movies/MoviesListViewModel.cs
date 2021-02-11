namespace MovieRatings.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;

    public class MoviesListViewModel : PagingViewModel
    {
        public IEnumerable<MovieInListViewModel> Movies { get; set; }
    }
}
