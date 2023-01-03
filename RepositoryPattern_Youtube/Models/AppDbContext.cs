using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern_Youtube.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed method call here
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Music> Music { get; set; } 
    }
}
