using Microsoft.AspNetCore.Mvc;
using MoodVerse.API.Models.RequestModel.Note;
using MoodVerse.Service.Dto.Note;
using MoodVerse.Service.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace MoodVerse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService NoteService;   

        public NoteController(INoteService noteService)
        {
            NoteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteRequestModel requestModel)
        {
            var sid = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sid)?.Value;

            var dto = new NoteDto()
            {
                PrimaryEmotionTypeId = requestModel.PrimaryEmotionTypeId,
                Text = requestModel.Text,
                Title = requestModel.Title,
                CreatorId = Guid.Parse(sid)
            };

            await NoteService.InsertAsync(dto);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotesAsync(Guid userId, int? skip, int? take)
        {
            var dto = await NoteService.GetAllAsync(userId, skip, take);

            return Ok(new { 
                Notes =  dto.Item1,
                Total = dto.total,
            });
        }
    }
}
