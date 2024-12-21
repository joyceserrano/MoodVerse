using Microsoft.EntityFrameworkCore;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class RefreshTokenRepository : Repository, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await Context.RefreshToken.SingleOrDefaultAsync(r => r.Token == token && r.Expiration > DateTime.UtcNow);
        }

         public async Task<RefreshToken?> GetByAccountIdAsync(Guid accountId)
        {
            return await Context.RefreshToken.SingleOrDefaultAsync(r => r.AccountId == accountId && r.Expiration > DateTime.UtcNow);
        }

        public async Task InsertAsync(RefreshToken refreshToken)
        {
            await Context.AddAsync(refreshToken);
        }

        public void DeleteAllByAccountId(Guid accountId)
        {
            var refreshTokens = Context.RefreshToken.Where(r => r.AccountId == accountId);
            Context.RefreshToken.RemoveRange(refreshTokens);
        }
    }
}
