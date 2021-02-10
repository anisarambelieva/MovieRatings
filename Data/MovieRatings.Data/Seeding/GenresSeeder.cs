namespace MovieRatings.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Drama" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Comedy" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Documentary" });
            await dbContext.Genres.AddAsync(new Models.Genre { Name = "Thriller" });

            await dbContext.SaveChangesAsync();
        }
    }
}
