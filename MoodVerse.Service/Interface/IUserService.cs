using MoodVerse.Data.Entity;
using MoodVerse.Service.Dto.User;

namespace MoodVerse.Service.Interface
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User> InsertAsync(InsertUserDto userDto);
    }
}
