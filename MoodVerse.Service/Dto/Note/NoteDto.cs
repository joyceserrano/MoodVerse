﻿namespace MoodVerse.Service.Dto.Note
{
    public class NoteDto
    {
        public Guid PrimaryEmotionTypeId { get; set; }
        public required string Text { get; set; }
        public required string Title { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
