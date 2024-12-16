using MoodVerse.Data.Entity;
using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Repository.Interface
{
    public interface INoteRepository : IRepository
    {
        Task InsertAsync(Note note);
    }
}
