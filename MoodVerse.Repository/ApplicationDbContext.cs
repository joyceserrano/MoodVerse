using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Data.Entity.Lookups;
using MoodVerse.Data.Mapping;
using MoodVerse.Data.Mapping.Lookup;

namespace MoodVerse.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<PrimaryEmotionType> PrimaryEmotionType { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new AccountMap(modelBuilder);
            new ArtistMap(modelBuilder);
            new NotesMap(modelBuilder);
            new PrimaryEmotionTypeMap(modelBuilder);
            new QuoteMap(modelBuilder);
            new UserMap(modelBuilder);
        }
    }
}
