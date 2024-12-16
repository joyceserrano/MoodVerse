using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class NoteRepository(ApplicationDbContext context) : Repository(context), INoteRepository
    {
        public async Task InsertAsync(Note note)
        {
            await Context.AddAsync(note);
        }
    }
}
