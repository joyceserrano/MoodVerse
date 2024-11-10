using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IArtistRepository : IRepository
    {
        Task InsertAsync(Artist artist);
    }
}