namespace MovieRatings.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieRatings.Services.Data;
    using MovieRatings.Web.ViewModels.Movies;

    public class MoviesController : Controller
    {
        private readonly IGenresService genresService;

        public MoviesController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateMovieInputModel();
            viewModel.GenresItems = this.genresService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.GenresItems = this.genresService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // TODO: Create movie using service method
            // TODO: Redirect to Movie page
            return this.Redirect("/");
        }
    }
}
