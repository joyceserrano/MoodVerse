using Hangfire;
using Microsoft.AspNetCore.Mvc;
using MoodVerse.Utility.Emails.Interface;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailDispatcher EmailDispatcher;

        public EmailController(IEmailDispatcher emailDispatcher)
        {
            EmailDispatcher = emailDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContinuationJob()
        {
            var scheduleDateTime = DateTime.UtcNow.AddSeconds(5);
            var dateTimeOffset = new DateTimeOffset(scheduleDateTime);

            var jobId = BackgroundJob.Schedule(() => EmailDispatcher.SendAsync("Taylor Swift Quotes", $@"Im intimidated by the fear of being average."), scheduleDateTime);

            return Ok(jobId);
        }
    }
}
