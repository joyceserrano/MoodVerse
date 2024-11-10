namespace MoodVerse.Service.Dto
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
