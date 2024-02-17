using Microsoft.EntityFrameworkCore;

namespace Mission06_Hales.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base (options)
        {

        }

        public DbSet<MovieCollection> MovieCollection {  get; set; }
    }
}
