using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Data.Entity
{
    public class Artist : Logged
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
