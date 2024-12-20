using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IAccountRepository : IRepository
    {
        Task<Account?> GetByUsernameAsync(string username);
        Task InsertAsync(Account account);
    }
}