using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Data.Entity
{
    public class Account : Logged
    {
      public required Guid UserId { get; set; }
      public User User { get; set; } = default!;
      public required string Hash { get; set; }
      public required string Salt { get; set; }
      public required string Username { get; set; }
    }
}