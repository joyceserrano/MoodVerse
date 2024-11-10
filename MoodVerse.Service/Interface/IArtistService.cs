using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto;

namespace MoodVerse.Service.Interface
{
    public interface IArtistService 
    {
        Task<ArtistDto> InsertAsync(ArtistDto artistDto);
    }
}
