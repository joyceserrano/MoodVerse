namespace MoodVerse.Service.Dto.Account
{
    public class InsertAccountDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }
    }
}
