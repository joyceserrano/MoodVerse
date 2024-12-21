using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class UserRepository(ApplicationDbContext context) : Repository(context), IUserRepository
    {
        public async Task InsertAsync(User user)
        {
            await Context.User.AddAsync(user);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await Context.User.SingleOrDefaultAsync(u => u.Id == id && !u.Deleted);
        }
    }
}
