namespace MovieRatings.Services.Data
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task SetVoteAsync(int movieId, string userId, byte value);

        double GetAverageVotes(int movieId);
    }
}
