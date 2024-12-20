namespace MoodVerse.API.Models.RequestModel.Note
{
    public class NoteRequestModel 
    {
        public Guid PrimaryEmotionTypeId { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
    }
}
