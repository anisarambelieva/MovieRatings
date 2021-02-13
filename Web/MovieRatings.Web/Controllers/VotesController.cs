namespace MovieRatings.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieRatings.Services.Data;
    using MovieRatings.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : BaseController
    {
        private readonly IVoteService voteService;

        public VotesController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<PostVoteResponseModel>> Post(PostVoteInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.voteService.SetVoteAsync(
                input.MovieId, userId, input.Value);

            var averageVote = this.voteService.GetAverageVotes(input.MovieId);

            return new PostVoteResponseModel { AverageVote = averageVote };
        }
    }
}
