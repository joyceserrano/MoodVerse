using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class AccountRepository(ApplicationDbContext context) : Repository(context), IAccountRepository
    {
        public async Task<Account?> GetByUsernameAsync(string username)
        {
            return await Context.Account.SingleOrDefaultAsync(a => a.Username == username);
        }

        public async Task<Account?> GetByUserIdAsync(Guid userId)
        {
            return await Context.Account.SingleOrDefaultAsync(a => a.UserId == userId && !a.Deleted);
        }

        public async Task<Account?> GetByIdAsync(Guid id)
        {
            return await Context.Account.SingleOrDefaultAsync(a => a.Id == id && !a.Deleted);
        }

        public async Task InsertAsync(Account account)
        {
            await Context.AddAsync(account);
        }
    }
}
