using MoodVerse.Service.Dto.Account;

namespace MoodVerse.Service.Interface
{
    public interface IAccountService 
    {
        Task<AccountDto?> GetByUserIdAsync(Guid userId);
        Task<AccountDto?> GetByUsernameAsync(string username);
        Task InsertAsync(InsertAccountDto accountDto);
        bool VerifyPassword(string password, string storedHash, string storedSalt);
    }
}
