namespace MovieRatings.Data.Models
{
    using MovieRatings.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
