namespace MovieRatings.Web.ViewModels.Movies
{
    using System.Linq;

    using AutoMapper;
    using MovieRatings.Data.Models;
    using MovieRatings.Services.Mapping;

    public class SingleMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string GenreName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, SingleMovieViewModel>()
               .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/movies/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
