using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.Note;

namespace MoodVerse.Service.Interface
{
    public interface INoteService
    {
        Task InsertAsync(NoteDto note);
    }
}
