using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class ArtistRepository(ApplicationDbContext context) : Repository(context), IArtistRepository
    {
        public async Task InsertAsync(Artist artist) { 
            await Context.AddAsync(artist);
        }
    }
}
