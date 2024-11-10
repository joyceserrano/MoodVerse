using MoodVerse.Data.Entity;
using MoodVerse.Repository.Implementation;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto;
using MoodVerse.Service.Interface;

namespace MoodVerse.Service.Implementation
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository ArtistRepository { get; }

        public ArtistService(ArtistRepository artistRepository) {
            ArtistRepository = artistRepository;
        }

        public async Task<ArtistDto> InsertAsync(ArtistDto artistDto)
        {
            var artist = new Artist()
            {
                FirstName = artistDto.FirstName,
                LastName = artistDto.LastName,
            };

            await ArtistRepository.InsertAsync(artist);
            await ArtistRepository.SaveChanges();

            return artistDto;
        }
    }
}
