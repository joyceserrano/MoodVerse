using AutoMapper;
using MoodVerse.Data.Entity.Lookups;
using MoodVerse.Repository.Implementation;
using MoodVerse.Service.Dto;
using MoodVerse.Service.Interface;

namespace MoodVerse.Service.Implementation
{
    public class LookupService : ILookupService
    {
        private ILookupRepository LookupRepository { get; }
        private IMapper Mapper { get; }

        public LookupService(ILookupRepository lookupRepository, IMapper mapper)
        {
            LookupRepository = lookupRepository;
            Mapper = mapper;
        }

        public async Task<IEnumerable<LookupDto>> GetAllPrimaryEmotionType()
        {
            var primaryEmotions = await LookupRepository.GetAllAsync<PrimaryEmotionType>();

            var dto = Mapper.Map<IEnumerable<LookupDto>>(primaryEmotions);

            return dto;
        }
    }
}
