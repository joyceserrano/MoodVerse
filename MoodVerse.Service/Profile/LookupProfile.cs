using MoodVerse.Data.Entity;
using MoodVerse.Data.Entity.Lookups;
using MoodVerse.Service.Dto;

namespace MoodVerse.Service.Profile
{
    public class LookupProfile : AutoMapper.Profile
    {
        public LookupProfile()
        {
            CreateMap<PrimaryEmotionType, LookupDto> ()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(d => d.Order, opt => opt.MapFrom(src => src.Order))
                .ForMember(d => d.Deleted, opt => opt.MapFrom(src => src.Deleted));
        }
    }
}
