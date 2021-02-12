namespace MovieRatings.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class PostVoteInputModel
    {
        public int MovieId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
