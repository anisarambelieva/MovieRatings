namespace MovieRatings.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<MovieInListViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var movies = this.moviesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new MovieInListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    GenreName = x.Genre.Name,
                    GenreId = x.GenreId,
                    ImageUrl =
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "images/movies/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                }).ToList();

            return movies;
        }

    }
}
