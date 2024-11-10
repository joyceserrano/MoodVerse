using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto;

namespace MoodVerse.Service.Profile
{
    public class ArtistProfile : AutoMapper.Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistDto>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
