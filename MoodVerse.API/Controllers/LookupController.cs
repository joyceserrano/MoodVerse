using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoodVerse.Service.Dto;
using MoodVerse.Service.Interface;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {

        private ILookupService LookupService {get;}

        public LookupController(ILookupService lookupService) {
           LookupService = lookupService;
        }

        [HttpGet("primary-emotion-type")]
        public async Task<IActionResult> GetAllPrimaryEmotionType()
        {
            var primaryEmotions = await LookupService.GetAllPrimaryEmotionType();

            if (primaryEmotions == null)
                return BadRequest("No Primary Emotions Found");

            return Ok(primaryEmotions);
        }
    }
}
