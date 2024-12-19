using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Account;
using System.Security.Cryptography;
using System.Text;

namespace MoodVerse.Service.Implementation
{
    public class AccountService
    {
        private IAccountRepository AccountRepository { get; set; }
        public AccountService(IAccountRepository accountRepository)
        {
            AccountRepository = accountRepository;
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
            };

            await AccountRepository.InsertAsync(newAccount);
        }

        public (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(25);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
               password,
               salt,
               iterations: 100_000,
               HashAlgorithmName.SHA256,
               outputLength: 32);

            return (Convert.ToBase64String(hash), Convert.ToBase64String(salt));
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
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[25];
            rng.GetBytes(salt);
            return salt;
        }

        private static string HashPassword(string password, byte[] salt)
        {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

            byte[] hashedBytes = SHA256.HashData(saltedPassword);

            byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
            Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
            Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

            return Convert.ToBase64String(hashedPasswordWithSalt);
        }
    }
}
