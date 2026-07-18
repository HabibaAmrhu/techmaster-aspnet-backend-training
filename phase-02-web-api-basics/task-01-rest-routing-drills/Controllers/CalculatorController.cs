using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using WebAPIproject.Services;

namespace WebAPIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ConverterService _converterService;

        public CalculatorController(ConverterService converterService)
        {
            _converterService=converterService;
        }

        [HttpGet("Add")]
        public  IActionResult Add([FromQuery] decimal a, [FromQuery] decimal b)
        {
            return Ok($"result = {a+b}");
        }

        [HttpGet("ConvertCelsiusToFahrenheit")]
        public ActionResult Convert(decimal cel)
        {
            decimal result = _converterService.ConvertCelsiusToFahrenheit(cel);
            return Ok($"fahrenheit = {result}");
        }

        [HttpGet("Grade")]
        public IActionResult Grades(decimal score)
        {
            if (score < 0 || score > 100) return BadRequest(new { error = "Score must be between 0 and 100" });
            string grade;
            if (score >= 90) grade = "grade A";
            else if (score >= 80) grade ="grade B";
            else if (score >= 70) grade ="grade C";
            else if (score < 50) grade ="grade F";
            else grade = "grade D";
                return Ok(grade);

        }
    }
}
