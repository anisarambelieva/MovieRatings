namespace MovieRatings.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using MovieRatings.Services.Data;
    using MovieRatings.Web.ViewModels.Movies;

    public class MoviesController : Controller
    {
        private readonly IGenresService genresService;
        private readonly IMoviesService moviesService;
        private readonly IWebHostEnvironment environment;

        public MoviesController(
            IGenresService genresService,
            IMoviesService moviesService,
            IWebHostEnvironment environment)
        {
            this.genresService = genresService;
            this.moviesService = moviesService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateMovieInputModel();
            viewModel.GenresItems = this.genresService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.GenresItems = this.genresService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            try
            {
                await this.moviesService.CreateAsync(input, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                input.GenresItems = this.genresService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // TODO: Redirect to Movie page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;

            var viewModel = new MoviesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                MoviesCount = this.moviesService.GetCount(),
                Movies = this.moviesService.GetAll<MovieInListViewModel>(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var movie = this.moviesService.GetById<SingleMovieViewModel>(id);
            return this.View(movie);
        }
    }
}
