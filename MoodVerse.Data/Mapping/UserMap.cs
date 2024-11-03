using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class UserMap
    {
        public UserMap(ModelBuilder modelBuilder) {
            var entityBuilder = modelBuilder.Entity<User>();

            entityBuilder.Property(q => q.FirstName).IsRequired();
            entityBuilder.Property(q => q.LastName).IsRequired();

            entityBuilder.
                 HasOne(u => u.Creator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                 HasOne(u => u.Modifier)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
