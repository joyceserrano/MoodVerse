using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.Note;

namespace MoodVerse.Service.Interface
{
    public interface INoteService
    {
        Task<(IEnumerable<Note>, int total)> GetAllAsync(Guid userId, int? skip = null, int? take = null);
        Task InsertAsync(NoteDto note);
    }
}
