namespace MovieRatings.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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

        public async Task CreateAsync(CreateMovieInputModel input, string imagePath)
        {
            var movie = new Movie();
            movie.GenreId = input.GenreId;
            movie.Name = input.Name;
            movie.Description = input.Description;

            var allowedExtensions = new[] { "jpg", "png", "gif" };

            Directory.CreateDirectory($"{imagePath}/movies/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    Movie = movie,
                    Extension = extension,
                };

                movie.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/movies/{dbImage.Id}.{extension}";

                using Stream filestream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(filestream);
            }

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

        public T GetById<T>(int id)
        {
            var movie = this.moviesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return movie;
        }

        public int GetCount()
        {
            return this.moviesRepository.All().Count();
        }
    }
}
