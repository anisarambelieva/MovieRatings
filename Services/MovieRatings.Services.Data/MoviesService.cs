namespace MovieRatings.Services.Data
{
    using System.Threading.Tasks;

    using MovieRatings.Data.Common.Repositories;
    using MovieRatings.Data.Models;
    using MovieRatings.Web.ViewModels.Movies;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public async Task CreateAsync(CreateMovieInputModel input)
        {
            var movie = new Movie();
            movie.GenreId = input.GenreId;
            movie.Name = input.Name;
            movie.Description = input.Description;

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
        }
    }
}
