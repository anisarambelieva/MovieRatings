namespace MovieRatings.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MovieRatings.Data.Common.Repositories;
    using MovieRatings.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votesRepository;

        public VoteService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVotes(int movieId)
        {
            var averageVotes = this.votesRepository.All()
                .Where(x => x.MovieId == movieId)
                .Average(x => x.Value);

            return averageVotes;
        }

        public async Task SetVoteAsync(int movieId, string userId, byte value)
        {
            var vote = this.votesRepository.All()
                .FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    MovieId = movieId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
