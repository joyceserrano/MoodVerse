namespace MoodVerse.Data.Entity
{
    public class RefreshToken 
    {
        public Guid Id { get; set; }
        public required string Token {  get; set; }
        public required DateTime Expiration { get; set; } 
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
