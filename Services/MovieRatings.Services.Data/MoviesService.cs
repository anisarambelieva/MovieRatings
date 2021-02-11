namespace MovieRatings.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieRatings.Data.Common.Repositories;
    using MovieRatings.Data.Models;
    using MovieRatings.Services.Mapping;
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

        public IEnumerable<Т> GetAll<Т>(int page, int itemsPerPage = 12)
        {
            var movies = this.moviesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<Т>()
                .ToList();

            return movies;
        }

        public int GetCount()
        {
            return this.moviesRepository.All().Count();
        }
    }
}
