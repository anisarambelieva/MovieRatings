namespace MovieRatings.Web.ViewModels.Movies
{
    using System.Linq;

    using AutoMapper;
    using MovieRatings.Data.Models;
    using MovieRatings.Services.Mapping;

    public class MovieInListViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieInListViewModel>()
               .ForMember(x => x.ImageUrl, opt =>
                   opt.MapFrom(x =>
                       x.Images.FirstOrDefault().RemoteImageUrl != null ?
                       x.Images.FirstOrDefault().RemoteImageUrl :
                       "/images/movies/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
