using System.ComponentModel.DataAnnotations;

namespace ProductsCatigoriesAPI.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int StockQuantity { get; set; }
        public string SupplierName { get; set; }
    }
}
