using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using System.Linq;

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
                .OrderByDescending(n => n.CreatedOn);

            int total = await query.CountAsync();

            var orderedQuery = query.Skip(skip.Value).Take(take.Value);

            //if (skip.HasValue)
            //    query = query.Skip(skip.Value);

            //if (take.HasValue)
            //    query = query.Take(take.Value);

            return (await orderedQuery.ToListAsync(), total);
        }
    }
}
