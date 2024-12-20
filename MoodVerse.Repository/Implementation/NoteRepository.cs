using Microsoft.EntityFrameworkCore;
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

        public async Task GetByUserId(Note note)
        {
            await Context.AddAsync(note);
        }
        public async Task<IEnumerable<Note>> GetAllAsync(Guid userId, int? skip, int? take)
        {
            var query = Context.Note
                .OrderByDescending(n => n.CreatedOn).AsQueryable();

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            return await query.ToListAsync();
        }
    }
}
