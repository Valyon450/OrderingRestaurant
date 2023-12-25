using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menurService;

        public MenuController(IMenuService menurService)
        {
            _menurService = menurService;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult<IEnumerable<PriceListNoteDTO>> Get()
        {
            var notes = _menurService.GetAllPriceListNotes();
            return notes.ToList();
        }

        // GET api/<MenuController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<PriceListNoteDTO>>> GetById(Guid id)
        {
            var note = await _menurService.GetPriceListNoteByIdAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PriceListNoteDTO noteModel)
        {
            try
            {
                await _menurService.AddPriceListNoteAsync(noteModel);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return CreatedAtAction(nameof(Post), new { noteModel.Id }, noteModel);
        }

        // DELETE api/<MenuController>/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _menurService.DeletePriceListNoteByIdAsync(id);

            return Ok();
        }
    }
}
