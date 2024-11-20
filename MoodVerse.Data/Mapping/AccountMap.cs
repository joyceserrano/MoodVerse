using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class AccountMap
    {
        public AccountMap(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Account>();

            entityBuilder.HasKey(a => a.Id);

            entityBuilder
               .HasOne(a => a.User)
               .WithOne()
               .OnDelete(DeleteBehavior.Restrict);

            entityBuilder
              .HasOne(a => a.Creator)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);

            entityBuilder
               .HasOne(a => a.Modifier)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
