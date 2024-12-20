using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Dto.Authentication;

namespace MoodVerse.Service.Interface
{
    public interface IAuthenticationService
    {
        TokenDto GenerateTokens(AccountDto account);
    }
}
