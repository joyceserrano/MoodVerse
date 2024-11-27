namespace MoodVerse.API.Models.RequestModel.User
{
    public class InsertUserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }    
        public string Password { get; set; }
    }
}
