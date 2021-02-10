namespace MovieRatings.Services.Data
{
    using MovieRatings.Services.Data.Models;
    using MovieRatings.Web.ViewModels.Home;

    public interface IGetCountsService
    {
        CountsDto GetCounts();
    }
}
