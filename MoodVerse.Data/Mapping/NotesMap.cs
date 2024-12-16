using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class NotesMap
    {
        public NotesMap(ModelBuilder modelBuilder) {

            var entityBuilder = modelBuilder.Entity<Notes>();

            entityBuilder.Property(n => n.Text).IsRequired();

            entityBuilder.Property(n => n.PrimaryEmotionTypeId).IsRequired();

            entityBuilder.
                 HasOne(n => n.PrimaryEmotionType)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                 HasOne(n => n.Creator)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.
                 HasOne(n => n.Modifier)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
