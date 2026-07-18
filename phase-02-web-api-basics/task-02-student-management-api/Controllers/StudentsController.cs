using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Services;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _student;

        public StudentsController(IStudentService student)
        {
            _student=student;
        }

        [HttpPost]
        public IActionResult AddStudent(CreateStudentDTO dto)
        {
            if (dto == null) { return BadRequest(new { message = "invalid input" }); }


            var student = _student.Create(dto);
            if (student == null) { return BadRequest(new { message = "Emails already Exists" }); }
            return Ok(dto);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllStudents(
    [FromQuery] string? keyword,
    [FromQuery] string? TrackName,
    [FromQuery] bool? isactive,
    [FromQuery] int pageNum = 1,
    [FromQuery] int PageSize = 10)
        {
            if (pageNum <= 0 || PageSize <= 0)
            {
                return BadRequest(new { message = "Page number and size must be greater than 0" });
            }

            var students = _student.GetAll(keyword, TrackName, isactive, pageNum, PageSize);
            return Ok(students);
        }


        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var s = _student.GetById(id);
            if (s == null) { return BadRequest(new { message = $"student with ID: {id} N OT FOUND" }); }

            return Ok(s);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "invalid input" });
            }
           var updated = _student.Update(id, dto);
            if (updated == null)
            {
                return NotFound(new { message = $"Student with ID {id} was not found." });
            }
            return Ok(updated);
        }



        [HttpPatch("{id}/status")]
        public IActionResult UpdateStudentStatus(int id, [FromBody] UpdateStudentStatusDTO dto)
        {
            if (dto == null)
            {
                return BadRequest(new { message = "invalid input" });
            }
            var updated = _student.UpdateStatus(id, dto);
            if (updated == null)
            {
                return NotFound(new { message = $"Student with ID {id} was not found." });
            }
            return Ok(new
            {
                message = $"Student status updated to {(dto.IsActive ? "Active" : "Inactive")}",
                studentId = updated.Id,
                isActive = updated.IsActive

            });
        }

        [HttpGet]
        public IActionResult BasicNumbers() =>
            Ok(_student.GetStats());
       

    }
}
