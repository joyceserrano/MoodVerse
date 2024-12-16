using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Note;
using MoodVerse.Service.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace MoodVerse.Service.Implementation
{
    public class NoteService : INoteService
    {
        private INoteRepository NoteRepository { get; }
        public NoteService(INoteRepository noteRepository)
        {
            NoteRepository = noteRepository;
        }

        public async Task InsertAsync(NoteDto noteDto)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),    
                PrimaryEmotionTypeId = noteDto.PrimaryEmotionTypeId,
                Text = noteDto.Text,
                CreatedOn = DateTime.UtcNow,
            };

            await NoteRepository.InsertAsync(note);
            await NoteRepository.SaveChanges();
        }
    }
}
