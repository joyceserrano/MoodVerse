using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IAccountRepository
    {
        Task InsertAsync(Account account);
    }
}