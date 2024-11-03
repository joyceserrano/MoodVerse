using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Data.Mapping;

namespace MoodVerse.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ArtistMap(modelBuilder);
            new QuoteMap(modelBuilder);
            new UserMap(modelBuilder);
        }
    }
}
