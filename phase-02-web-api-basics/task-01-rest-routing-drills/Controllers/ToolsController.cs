using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet("echo/{name}")]
        public IActionResult echo(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return BadRequest("Name Is Required"); }
            return Ok(name);
        }
    }
}
