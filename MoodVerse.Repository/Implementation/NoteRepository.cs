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
        public async Task<(IEnumerable<Note>, int total)> GetAllAsync(Guid userId, int? skip, int? take)
        {
            var query = Context.Note.Where(n => n.CreatorId == userId)
                .OrderByDescending(n => n.CreatedOn)
                .Skip(skip.Value)
                .Take(take.Value);

            int total = await query.CountAsync();

            return (await query.ToListAsync(), total);
        }
    }
}
