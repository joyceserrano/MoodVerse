using MoodVerse.Data.Entity;
using MoodVerse.Data.Entity.Initial;
using MoodVerse.Repository.Implementation;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.User;

namespace MoodVerse.Service.Implementation
{
    public class UserService
    {
        private IUserRepository UserRepository { get; }
        public UserService(IUserRepository userRepository) {
            UserRepository = userRepository;
        }

        public async Task InsertAsync(InsertUserDto userDto) 
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
        }
    }
}
