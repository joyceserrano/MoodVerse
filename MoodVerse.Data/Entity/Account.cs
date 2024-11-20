using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Data.Entity
{
    public class Account : Logged
    {
      public required Guid UserId { get; set; }
      public required User User { get; set; }
      public required string Hash { get; set; }
      public required string Salt { get; set; }
    }
}