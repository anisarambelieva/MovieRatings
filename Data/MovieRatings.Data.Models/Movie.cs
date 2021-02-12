namespace MovieRatings.Data.Models
{
    using System.Collections.Generic;

    using MovieRatings.Data.Common.Models;

    public class Movie : BaseDeletableModel<int>
    {
        public Movie()
        {
            this.Images = new HashSet<Image>();
            this.Votes = new HashSet<Vote>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
