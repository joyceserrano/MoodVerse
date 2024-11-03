using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class QuoteMap
    {
        public QuoteMap(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<Quote>();

            entityBuilder.HasKey(q => q.Id);
            entityBuilder.Property(q => q.Content).IsRequired();
            entityBuilder.Property(q => q.ArtistId).IsRequired();

            entityBuilder.
                 HasOne(q => q.Artist)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                 HasOne(q => q.Creator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                 HasOne(q => q.Modifier)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
