namespace MovieRatings.Data.Models
{
    using System.Collections.Generic;

    using MovieRatings.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
