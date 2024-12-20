using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface INoteRepository : IRepository
    {
        Task<IEnumerable<Note>> GetAllAsync(Guid userId, int? skip, int? take);
        Task InsertAsync(Note note);
    }
}
