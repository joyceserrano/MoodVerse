using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoodVerse.Service.Interface;
using MoodVerse.Utility.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace MoodVerse.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {

        private IOptions<Jwt> JwtInfo { get; }

        public AuthenticationService(IOptions<Jwt> jwtInfo)
        {
            JwtInfo = jwtInfo;
        }

        public void LoginAsync(string username, string password)
        {
            var accessToken = GenerateToken();
            var refreshToken = GenerateRefreshToken();
        }
        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: JwtInfo.Value.Issuer,
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
