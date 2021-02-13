namespace MovieRatings.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieRatings.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel input, string imagePath);

        IEnumerable<Т> GetAll<Т>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditMovieInputModel input);
    }
}
