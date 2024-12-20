using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.Account;

namespace MoodVerse.Service.Profile
{
    public class AccountProfile : AutoMapper.Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(d => d.Hash, opt => opt.MapFrom(src => src.Hash))
                .ForMember(d => d.Salt, opt => opt.MapFrom(src => src.Salt));

            CreateMap<InsertAccountDto, Account>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(d => d.Username, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
