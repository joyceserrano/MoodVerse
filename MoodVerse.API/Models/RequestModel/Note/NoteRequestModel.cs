namespace MoodVerse.API.Models.RequestModel.Note
{
    public class NoteRequestModel 
    {
        public Guid PrimaryEmotionTypeId { get; set; }
        public string Text { get; set; }
    }
}
