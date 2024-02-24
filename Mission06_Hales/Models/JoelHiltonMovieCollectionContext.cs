using Microsoft.EntityFrameworkCore;

namespace Mission06_Hales.Models
{
    public class JoelHiltonMovieCollectionContext : DbContext
    {
        public JoelHiltonMovieCollectionContext(DbContextOptions<JoelHiltonMovieCollectionContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies {  get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
