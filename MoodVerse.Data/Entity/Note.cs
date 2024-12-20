using MoodVerse.Data.Entity.Initial;
using MoodVerse.Data.Entity.Lookups;

namespace MoodVerse.Data.Entity
{
    public class Note : Logged
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid PrimaryEmotionTypeId { get; set; }
        public PrimaryEmotionType PrimaryEmotionType { get; set; }
    }
}
