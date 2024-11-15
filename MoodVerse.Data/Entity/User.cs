using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Data.Entity
{
    public class User : Logged
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
