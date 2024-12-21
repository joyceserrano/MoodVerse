using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

        public AuthenticationService(
            IOptions<Jwt> jwtInfo,
            IAccountRepository accountRepository)
        {
            JwtInfo = jwtInfo;
        }

        public TokenDto GenerateTokens(AccountDto account)
        {
            var accessToken = GenerateJwtToken(account);
            var refreshToken = GenerateRefreshToken();

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
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
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static string GenerateRefreshToken()
        {
            using var rng = RandomNumberGenerator.Create();

            byte[] tokenBuffer = new byte[25];
            rng.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }
    }
}
