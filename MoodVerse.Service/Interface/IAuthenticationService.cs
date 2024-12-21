using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Dto.Authentication;

namespace MoodVerse.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<TokenDto> GenerateTokensAsync(AccountDto account);
        Task<RefreshToken?> GetRefreshTokenByAccountIdAsync(Guid accountId);
    }
}
    