using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity.Initial;

namespace MoodVerse.Repository.Implementation
{
    public class LookupRepository(ApplicationDbContext context) : Repository(context), ILookupRepository
    {
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : LookupBase
        {
            return await Context.Set<T>().OrderBy(c => c.Order).ToListAsync();
        }
    }
}
