using MoodVerse.Repository.Entity.Initial;

namespace MoodVerse.Data.Entity
{
    public class Quote : Logged
    {
        public required string Content { get; set; }
        public Guid ArtistId { get; set; }
        public required Artist Artist { get; set; }
    }
}
