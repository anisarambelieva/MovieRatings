namespace MovieRatings.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MovieRatings.Services.Data;
    using MovieRatings.Web.ViewModels.Movies;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly IGenresService genresService;
        private readonly IMoviesService moviesService;

        public MoviesController(
            IGenresService genresService,
            IMoviesService moviesService)
        {
            this.genresService = genresService;
            this.moviesService = moviesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateMovieInputModel();
            viewModel.GenresItems = this.genresService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.GenresItems = this.genresService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.moviesService.CreateAsync(input);

            // TODO: Redirect to Movie page
            return this.Redirect("/");
        }
    }
}
