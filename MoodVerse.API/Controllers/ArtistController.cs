using Microsoft.AspNetCore.Mvc;
using MoodVerse.Service.Dto;
using MoodVerse.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private IArtistService ArtistService { get; }

        public ArtistController(IArtistService artistService) {
            ArtistService = artistService;  
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(ArtistDto artist)
        {
            var dto = await ArtistService.InsertAsync(artist);
            return Ok(dto.Id);
        }
    }
}
