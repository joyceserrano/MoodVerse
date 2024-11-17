using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoodVerse.Utility.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string JwtKey  {get; }

        public LoginController(IOptions<Jwt> Jwt)
        {
            JwtKey = Jwt.Value.Key;
        } 

        [HttpGet]
        public IActionResult Login()
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs on model");

            var token = GenerateToken();

            return Ok(token);
        }
        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
