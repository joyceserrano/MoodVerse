using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoodVerse.API.Models.RequestModel.Account;
using MoodVerse.Service.Dto.Account;
using MoodVerse.Service.Dto.User;
using MoodVerse.Service.Interface;
using MoodVerse.Utility.JWT.Model;

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

            var tokens = AuthenticationService.GenerateTokens(account);

            return Ok(tokens);
        }

        [HttpPost("create-user")]
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

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Test Succeeded");
        }
    }
}
