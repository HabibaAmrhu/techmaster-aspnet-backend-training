using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {


        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok(new { status = "Running", service = "TechMaster API", time = DateTime.UtcNow });
        }

        [HttpGet("ok-demo")]
        public IActionResult GetSuccess() => Ok(new { message = "Data retrieved successfully" });

        [HttpPost("created-demo")]
        public IActionResult CreateDemo() => Created("/api/statuspractice/1", new { id = 1, status = "Created" });

        [HttpDelete("no-content-demo")]
        public IActionResult DeleteDemo() => NoContent();

        [HttpGet("bad-request-demo")]
        public IActionResult BadRequestDemo(int age)
        {
            if (age < 0) return BadRequest(new { error = "Age cannot be negative" });
            return Ok(new { age });
        }

        [HttpGet("not-found-demo/{id}")]
        public IActionResult NotFoundDemo(int id)
        {
            if (id != 1) return NotFound(new { error = $"Resource with id {id} not found" });
            return Ok(new { id, name = "Found Item" });
        }

        [HttpGet("demo")]
        public IActionResult GetErrorDemo([FromQuery] string type)
        {
            if (type == "bad")
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Invalid request",
                    errors = new[] { "Name is required", "Age must be positive" }
                });
            }

            if (type == "notfound")
            {
                return NotFound(new
                {
                    success = false,
                    message = "Resource not found",
                    code = 404
                });
            }

            return Ok(new { message = "Send type = bad or type = notfound to see error shapes" });
        }

    }
}
