namespace MoodVerse.Service.Dto.Account
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Hash { get; set; }
        public required string Salt { get; set; }
    }
}