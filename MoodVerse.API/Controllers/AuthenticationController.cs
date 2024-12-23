using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoodVerse.API.Models.RequestModel.Account;
using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Dto.User;
using MoodVerse.Service.Interface;
using MoodVerse.Utility.JWT.Model;
using System.IdentityModel.Tokens.Jwt;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IOptions<Jwt> JwtInfo {get; }
        private IAccountService AccountService { get; }
        private IUserService UserService { get; }
        private IAuthenticationService AuthenticationService { get; }

        public AuthenticationController(IOptions<Jwt> jwtInfo, IAccountService accountService, IUserService userService, IAuthenticationService authenticationService)
        {
            JwtInfo = jwtInfo;
            AccountService = accountService;
            UserService = userService;
            AuthenticationService = authenticationService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs on model");

            var account = await AccountService.GetByUsernameAsync(loginRequestModel.Username);

            if (account == null) 
                return NotFound("Username not found");

            var isPasswordValid = AccountService.VerifyPassword(loginRequestModel.Password, account.Hash, account.Salt);

            if (!isPasswordValid) 
                return BadRequest("Password Wrong");

            var tokens = await AuthenticationService.GenerateTokensAsync(account);

            Response.SetSecureCookie("refreshToken", tokens.RefreshToken);

            return Ok(new { tokens.AccessToken });
        }
        
        [HttpGet("self")]
        [Authorize]
        public async Task<IActionResult> GetUserAsync()
        {
            var sid = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;

            if (sid == null)
                return Unauthorized("SID claim is missing.");

            var userId = Guid.Parse(sid);
            var userDto = await UserService.GetByIdAsync(userId);

            if (userDto == null)
                return NotFound("User not found.");

            return Ok(userDto);
        }

        [HttpPost("user")] 
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid inputs on model");

            var userDto = new InsertUserDto()
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                EmailAddress = requestModel.EmailAddress,
            };

            var user = await UserService.InsertAsync(userDto);

            var accountDto = new InsertAccountDto()
            {
                UserName = requestModel.Username,
                Password = requestModel.Password,
                UserId = user.Id,
            };

            await AccountService.InsertAsync(accountDto);

            return Ok(user.Id);
        }

        [HttpPost("refresh/{userId}")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshTokenAsync(Guid userId)
        {
            
            var sid = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;

            if (userId != Guid.Parse(sid))
                return Unauthorized("User is invalid");

            var account = await AccountService.GetByUserIdAsync(userId);

            if (account == null)
                return NotFound("Account not found");

            var refreshTokenCookie = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshTokenCookie))
            {
                return Unauthorized("Refresh token cookie is missing.");
            }

            var refreshToken = await AuthenticationService.GetRefreshTokenByAccountIdAsync(account.Id);
            
            if (refreshToken == null || refreshTokenCookie != refreshToken.Token || refreshToken.Expiration < DateTime.UtcNow)
            {
                return Unauthorized("Invalid or expired refresh token.");
            }

            var tokens = await AuthenticationService.GenerateTokensAsync(account);

            Response.Cookies.Delete("refreshToken");
            Response.SetSecureCookie("refreshToken", tokens.RefreshToken);

            return Ok(new { tokens.AccessToken });
        }
    }
}
