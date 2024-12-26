using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MoodVerse.Data.Entity;
using MoodVerse.Repository.Interface;
using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Dto.Authentication;
using MoodVerse.Service.Interface;
using MoodVerse.Utility.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MoodVerse.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private IOptions<Jwt> JwtInfo { get; }
        private IRefreshTokenRepository RefreshTokenRepository { get; }

        public AuthenticationService(
            IOptions<Jwt> jwtInfo,
            IAccountRepository accountRepository,
            IRefreshTokenRepository refreshTokenRepository)
        {
            JwtInfo = jwtInfo;
            RefreshTokenRepository = refreshTokenRepository;
        }

        public async Task<TokenDto> GenerateTokensAsync(AccountDto account)
        {
            var accessToken = GenerateJwtToken(account);
            var refreshToken = await InsertRefreshToken(account);

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<RefreshToken?> GetRefreshTokenByAccountIdAsync(Guid accountId)
        {
            return await RefreshTokenRepository.GetByAccountIdAsync(accountId);
        }

        private string GenerateJwtToken(AccountDto account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, account.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new Claim("Username", account.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: JwtInfo.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<string> InsertRefreshToken(AccountDto accountDto)
        {
            var accountId = accountDto.Id;

            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = GenerateRefreshToken(),
                AccountId = accountId,
                Expiration = DateTime.UtcNow.AddDays(1)
            };

            RefreshTokenRepository.DeleteAllByAccountId(accountId);
            await RefreshTokenRepository.SaveChanges();

            await RefreshTokenRepository.InsertAsync(refreshToken);
            await RefreshTokenRepository.SaveChanges();

            return refreshToken.Token;
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(25));
        }
    }
}
