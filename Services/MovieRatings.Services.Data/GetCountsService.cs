namespace MovieRatings.Services.Data
{
    using MovieRatings.Data.Common.Repositories;
    using MovieRatings.Data.Models;
    using MovieRatings.Services.Data.Models;
    using MovieRatings.Web.ViewModels.Home;
    using System.Linq;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<Movie> moviesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Genre> genresRepository,
            IRepository<Image> imagesRepository,
            IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.genresRepository = genresRepository;
            this.imagesRepository = imagesRepository;
            this.moviesRepository = moviesRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                GenresCount = this.genresRepository.All().Count(),
                MoviesCount = this.moviesRepository.All().Count(),
            };

            return data;
        }
    }
}
