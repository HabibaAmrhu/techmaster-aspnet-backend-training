using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIproject.DTOs;
using WebAPIproject.Repositories.Interfaces;
using WebAPIproject.Repositories.Repos;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotes _notes;

        public NotesController(INotes notes)
        {
            _notes=notes;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateNoteRequestDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.title))
            {
                return BadRequest(new { error = "Title is required" });
            }

            var coun = _notes.GetAll();
            Notes notes = new Notes();
            notes.Id = coun.Count+1;
            notes.CreatedDate = DateTime.Now;
            notes.title = dto.title;
            notes.content = dto.content;

            _notes.Add(notes);

            return Created();
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var notes = _notes.GetAll();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIds(int id)
        {
            var note = _notes.GetById(id);
            if (note == null)
            {
                return NotFound($"Note with id {id} not found");
            }
            return Ok(note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, UpdateNoteRequest dto)
        {
            var note = _notes.GetById(id);
            if (note == null)
            {
                return NotFound($"Note with id {id} not found");
            }

            var isUpdated = _notes.Update(id, dto);
            if (!isUpdated) return NotFound("note doesn't exist");

            var updated = _notes.GetById(id);
            return Ok(updated);
        }

        [HttpGet("search")]
        public IActionResult search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { error = "Search keyword is required" });
            }
            var notes = _notes.Search(keyword);
            if (notes.Count == 0)
            {
                return Ok(new { message = "No matching notes found", results = notes });
            }
            return Ok(notes);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _notes.GetById(id);
            if (note == null)
            {
                return NotFound(new { message = $"Note with id {id} not found" });
            }

            var isDeleted = _notes.Delete(id);
            if (!isDeleted) return NotFound(new { message = $"Note with id {id} not found" });

            return NoContent();
        }

        [HttpGet("Page")]
        public IActionResult Pagination(int Pnum, int Psize)
        {
            if (Pnum<=0 || Psize<=0 || Psize >50) { return BadRequest(new { message = "invalid input" }); }
            var totalCount = _notes.GetTotalCount();

            var n = _notes.Pagination(Pnum, Psize);            
            return Ok(new
            {
                items = n,
                PageNumber = Pnum,
                PageSize = Psize,
                TotalCount = totalCount
            });
        }

        [HttpGet("request-info")]
        public IActionResult GetRequestInfo([FromHeader(Name = "Put your Name")] string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                return BadRequest(new { error = "Student-Name header is missing" });
            }

            return Ok(new
            {
                headerValue = studentName,
                requestPath = Request.Path.HasValue
            });
        }
    }
}