using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class AccountRepository(ApplicationDbContext context) : Repository(context), IAccountRepository
    {
        public async Task InsertAsync(Account account)
        {
            await Context.AddAsync(account);
        }
    }
}
