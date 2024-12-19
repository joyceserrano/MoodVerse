using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IAccountRepository : IRepository
    {
        Task InsertAsync(Account account);
    }
}