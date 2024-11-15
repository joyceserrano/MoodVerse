namespace MoodVerse.Data.Entity.Initial
{
    public class LookupBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool Deleted { get; set; }
    }
}
