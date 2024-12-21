using MoodVerse.Data.Entity;

namespace MoodVerse.Repository.Interface
{
    public interface IRefreshTokenRepository : IRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task InsertAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByAccountIdAsync(Guid accountId);
        void DeleteAllByAccountId(Guid accountId);
    }
}
