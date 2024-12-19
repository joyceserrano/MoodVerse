using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Account;

namespace MoodVerse.Service.Interface
{
    public interface IAccountService 
    {
        Task InsertAsync(InsertAccountDto accountDto);
    }
}
