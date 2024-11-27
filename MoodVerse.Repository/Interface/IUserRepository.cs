using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IUserRepository : IRepository
    {
        Task InsertAsync(User user);
    }
}