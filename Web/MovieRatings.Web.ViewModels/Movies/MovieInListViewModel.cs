namespace MovieRatings.Web.ViewModels.Movies
{
    public class MovieInListViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; }
    }
}
