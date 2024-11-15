using MoodVerse.Data.Entity;

namespace MoodVerse.Data.Entity.Initial
{
    public class Logged : Base
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? CreatorId { get; set; }
        public User? Creator { get; set; }
        public Guid? ModifierId { get; set; }
        public User? Modifier { get; set; }
    }
}
