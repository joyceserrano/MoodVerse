using MoodVerse.Data.Entity.Initial;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public interface ILookupRepository : IRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : LookupBase;
    }
}
