namespace MoodVerse.Service.Dto.User
{
    public class InsertUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid? CreatorId { get; set; }
    }
}

