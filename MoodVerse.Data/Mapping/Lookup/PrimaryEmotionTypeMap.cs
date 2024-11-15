using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity.Lookups;

namespace MoodVerse.Data.Mapping.Lookup
{
    public class PrimaryEmotionTypeMap
    {
        public PrimaryEmotionTypeMap(ModelBuilder modelBuilder)
        {

            var entityBuilder = modelBuilder.Entity<PrimaryEmotionType>();

            entityBuilder.Property(e => e.Name).IsRequired();

            entityBuilder.HasKey(e => e.Id);

            entityBuilder.HasData(
             [
                new() {
                   Id = new Guid("8218caf3-2f43-4f25-8d93-a3799d4ed4b1"),
                   Name = "Happy",
                   Order = 1
                },
                new() {
                   Id = new Guid("2ecd6a10-9b48-4ace-b067-41e64970b652"),
                   Name = "Sad",
                   Order = 2
                },
                 new() {
                   Id = new Guid("aabd1cf6-9828-4d67-9a24-3fe8084a5259"),
                   Name = "Disgusted",
                   Order = 3
                },
                 new() {
                   Id = new Guid("f2a3fc65-5a98-4363-8103-4d0b30c9df45"),
                   Name = "Angry",
                   Order = 4
                },
                 new() {
                   Id = new Guid("d3b6f6ba-0720-437d-80ec-edf9b463e469"),
                   Name = "Fearful",
                   Order = 5
                },
                 new() {
                   Id = new Guid("9eb10e85-9dee-4cd4-b181-e8142dfe2ddc"),
                   Name = "Bad",
                   Order = 6
                },
                 new() {
                   Id = new Guid("c9157a17-c48c-4f92-946f-dcb13d0b9199"),
                   Name = "Surprised",
                   Order = 7
                },
             ]);
        }
    }
}
