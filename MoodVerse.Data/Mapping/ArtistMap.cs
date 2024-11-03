using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using System.Reflection.Emit;


namespace MoodVerse.Data.Mapping
{
    public class ArtistMap
    {
        public ArtistMap(ModelBuilder modelBuilder) {

            var entityBuilder = modelBuilder.Entity<Artist>();

            entityBuilder.Property(a => a.FirstName).IsRequired();

            entityBuilder.
                HasOne(a => a.Creator)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                HasOne(a => a.Modifier)
               .WithMany()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
