﻿namespace MoodVerse.API.Models.RequestModel.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
