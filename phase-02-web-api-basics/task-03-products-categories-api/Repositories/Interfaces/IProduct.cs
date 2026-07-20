using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Models;

namespace ProductsCatigoriesAPI.Repositories.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAll();
        Product Create(CreateProductDto dto);
        void Delete(int id);
        void Update(int id, UpdateProductDto dto);
        Product GetByID(int id);
        public List<Product> GetFilteredProducts(
   string? name,
   int? categoryId,
   decimal? minPrice,
   decimal? maxPrice,
   bool? isAvailable,
   bool? onlyLowStock);


        public decimal GetTotalStockValue();
        public List<Product> GetLowStockProducts();
        public List<Product> GetOutOfStockProducts();
        public object GetCategoryReport();
    }


}
