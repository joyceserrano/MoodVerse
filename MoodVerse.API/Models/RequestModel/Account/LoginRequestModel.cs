using System.ComponentModel.DataAnnotations;

namespace MoodVerse.API.Models.RequestModel.Account
{
    public class LoginRequestModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
