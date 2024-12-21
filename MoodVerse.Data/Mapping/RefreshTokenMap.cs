using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Mapping
{
    public class RefreshTokenMap 
    {
        public RefreshTokenMap(ModelBuilder modelBuilder)
        {
            var entityBuilder = modelBuilder.Entity<RefreshToken>();

            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.Token).IsRequired();
            entityBuilder.Property(r => r.Expiration).IsRequired();
            entityBuilder.Property(r => r.AccountId).IsRequired();

            entityBuilder
                .HasOne(r => r.Account)
                .WithMany();
        }
    }
}
