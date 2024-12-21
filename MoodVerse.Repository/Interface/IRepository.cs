using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IRepository
    {
        Task SaveChanges();
    }
}
