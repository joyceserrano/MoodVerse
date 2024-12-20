using AutoMapper;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Interface;
using System.Security.Cryptography;

namespace MoodVerse.Service.Implementation
{
    public class AccountService  : IAccountService
    {
        private IAccountRepository AccountRepository { get; set; }
        private IMapper Mapper { get; set; }

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            AccountRepository = accountRepository;
            Mapper = mapper;
        }

        public async Task<AccountDto?> GetByUsernameAsync(string username)
        {
            var account = await AccountRepository.GetByUsernameAsync(username);

            if (account == null)
                return null;

            return Mapper.Map<AccountDto>(account);
        }

        public async Task InsertAsync(InsertAccountDto accountDto)
        {
            var salt = GenerateSalt();
            var hash = HashPassword(accountDto.Password, salt);
            string base64Salt = Convert.ToBase64String(salt);

            var newAccount = new Account()
            {
                Username = accountDto.UserName,
                UserId = accountDto.UserId,
                Salt = base64Salt,
                Hash = hash,
                CreatedOn = DateTime.Now,
            };

            await AccountRepository.InsertAsync(newAccount);
            await AccountRepository.SaveChanges();
        }

        private static string HashPassword(string password, byte[] salt)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 100_000,
                HashAlgorithmName.SHA256,
                outputLength: 32);

            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password,
                saltBytes,
                iterations: 100_000,
                HashAlgorithmName.SHA256,
                outputLength: 32);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, hashBytes);
        }

        private static byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(25);
        }
    }
}
