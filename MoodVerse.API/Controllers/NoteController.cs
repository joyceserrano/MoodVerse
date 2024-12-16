using Microsoft.AspNetCore.Mvc;
using MoodVerse.API.Models.RequestModel.Note;
using MoodVerse.Service.Dto.Note;
using MoodVerse.Service.Interface;

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
            var dto = new NoteDto()
            {
                PrimaryEmotionTypeId = requestModel.PrimaryEmotionTypeId,
                Text = requestModel.Text
            };

            await NoteService.InsertAsync(dto);

            return Ok(dto);
        }
    }
}
