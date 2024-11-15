using MoodVerse.Service.Dto;

namespace MoodVerse.Service.Interface
{
    public interface ILookupService
    {
        Task<IEnumerable<LookupDto>> GetAllPrimaryEmotionType();
    }
}