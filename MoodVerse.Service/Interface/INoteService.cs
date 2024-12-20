using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.Note;

namespace MoodVerse.Service.Interface
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllAsync(Guid userId, int? skip, int? take);
        Task InsertAsync(NoteDto note);
    }
}
