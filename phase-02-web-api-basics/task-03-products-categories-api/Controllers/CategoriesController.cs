using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Repositories.Interfaces;

namespace ProductsCatigoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category=category;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCategories()
        {
            var cat = _category.GetAll();
            return Ok(cat);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategorydto dto)
        {
            if (dto == null) return BadRequest(new { message = "Invalid Input" });
            if (string.IsNullOrWhiteSpace(dto.Name)) return BadRequest(new { message = "Name Is Required" });
            var c = _category.Create(dto);
            return CreatedAtAction(nameof(GetCategory), new { id = c.CategoryId }, c);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var c = _category.GetByID(id);
            if (c == null) { return NotFound(new {message=$"Category With ID:{id} Not Found"}); }
            _category.Delete(id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var product = _category.GetByID(id);
            if (product == null) { return NotFound(new {message = $"Product with ID : {id} Not Found"}); }
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id ,UpdateCatDTO dto)
        {
            var c = _category.GetByID(id);
            if (c == null) { return NotFound(new { message = $"Category With ID:{id} Not Found" }); }
              _category.Update(id, dto);

            return Ok(new
            {
                updated = true,
            });

        }       
    }
}

