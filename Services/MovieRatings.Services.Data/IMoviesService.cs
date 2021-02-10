namespace MovieRatings.Services.Data
{
    using System.Threading.Tasks;

    using MovieRatings.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel input);
    }
}
