namespace MoodVerse.Service.Dto
{
    public class LookupDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Order { get; set; }
        public bool Deleted { get; set; }
    }
}
