using System.ComponentModel.DataAnnotations;

namespace MoodVerse.API.Models.RequestModel.Account
{
    public class CreateUserRequestModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }

        [EmailAddress]
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}