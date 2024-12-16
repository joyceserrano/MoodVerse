using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class NoteMap
    {
        public NoteMap(ModelBuilder modelBuilder) {

            var entityBuilder = modelBuilder.Entity<Note>();

            entityBuilder.HasKey(n => n.Id);

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
