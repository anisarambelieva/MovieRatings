namespace MovieRatings.Data.Models
{
    using System;

    using MovieRatings.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}
