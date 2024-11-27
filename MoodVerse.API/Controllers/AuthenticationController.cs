using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoodVerse.API.Models.RequestModel.Login;
using MoodVerse.Utility.JWT.Model;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IOptions<Jwt> JwtInfo {get; }

        public AuthenticationController(IOptions<Jwt> jwtInfo)
        {
            JwtInfo = jwtInfo;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs on model");

            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Test Succeeded");
        }
    }
}
