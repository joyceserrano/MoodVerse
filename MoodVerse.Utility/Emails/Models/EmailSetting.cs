namespace MoodVerse.Utility.Emails.Models
{
    public class EmailSetting
    {
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Host { get; set; }
        public int Port { get; set; }
        public string? TestEmail { get; set; }
    }
}
