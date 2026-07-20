using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Repositories.Interfaces;

namespace ProductsCatigoriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product=product;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _product.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _product.GetByID(id);
            if (product == null) { return NotFound(new { message = $"Product with ID: {id} Not Found" }); }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _product.GetByID(id);
            if (product == null) { return NotFound(new { message = $"Product with ID: {id} Not Found" }); }
                _product.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id , UpdateProductDto dto)
        {
            var product = _product.GetByID(id);
            if (product == null) { return NotFound(new { message = $"Product with ID: {id} Not Found" }); }
            if (dto == null) { return BadRequest(new { Message = "Invalid Input" }); }
           _product.Update(id, dto);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            if (dto == null) { return BadRequest(new { message = "Invalid Input" }); }
            if (dto.Price <= 0) return BadRequest(new { message = "Price must be positive" });

            var created = _product.Create(dto);
            return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
        }

        [HttpGet("Filtering")]
        public IActionResult GetProducts(
            [FromQuery] string? name,
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] bool? isAvailable,
            [FromQuery] bool? onlyLowStock)
        {
            var results = _product.GetFilteredProducts(name, categoryId, minPrice, maxPrice, isAvailable, onlyLowStock);

            return Ok(results);
        }


        [HttpGet("reports/inventory-summary")]
        public IActionResult GetInventorySummary()
        {
            var summary = new
            {
                TotalValue = _product.GetTotalStockValue(),
                LowStockCount = _product.GetLowStockProducts().Count,
                OutOfStockCount = _product.GetOutOfStockProducts().Count,
                CategoryBreakdown = _product.GetCategoryReport()
            };
            return Ok(summary);
        }

        [HttpGet("low-stock")]
        public IActionResult GetLowStock()
            => Ok(_product.GetLowStockProducts());
    }
}
