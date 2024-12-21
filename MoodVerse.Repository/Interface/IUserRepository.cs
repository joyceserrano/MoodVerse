using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IUserRepository : IRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task InsertAsync(User user);
    }
}