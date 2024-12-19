using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.User;
using MoodVerse.Service.Interface;

namespace MoodVerse.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }

        public UserService(IUserRepository userRepository) {
            UserRepository = userRepository;
        }

        public async Task<User> InsertAsync(InsertUserDto userDto) 
        {
            var user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userDto.CreatorId,
                EmailAddress = userDto.EmailAddress,
            }; 

            await UserRepository.InsertAsync(user);
            await UserRepository.SaveChanges();

            return user;
        }
    }
}
