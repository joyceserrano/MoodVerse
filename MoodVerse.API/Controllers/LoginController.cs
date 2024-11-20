using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoodVerse.API.Models.RequestModel.Login;
using MoodVerse.Utility.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IOptions<Jwt> JwtInfo {get; }

        public LoginController(IOptions<Jwt> jwtInfo)
        {
            JwtInfo = jwtInfo;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs on model");

            var token = GenerateToken();

            return Ok(token);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Test Succeeded");
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
    }
}
