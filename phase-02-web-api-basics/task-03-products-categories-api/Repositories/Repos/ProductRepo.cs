using Microsoft.AspNetCore.Mvc;
using ProductsCatigoriesAPI.Controllers;
using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Models;
using ProductsCatigoriesAPI.Repositories.Interfaces;
using ServiceStack;
using System;

namespace ProductsCatigoriesAPI.Repositories.GenericRepos
{
    public class ProductRepo : IProduct
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Laptop Pro 14", Price = 45000m, StockQuantity = 5, SupplierName = "TechSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 2, CategoryId = 1, Name = "Wireless Mouse", Price = 650m, StockQuantity = 50, SupplierName = "TechSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 3, CategoryId = 1, Name = "Mechanical Keyboard", Price = 2500m, StockQuantity = 7, SupplierName = "TechSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 4, CategoryId = 1, Name = "Monitor 27 inch", Price = 9000m, StockQuantity = 4, SupplierName = "TechSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 5, CategoryId = 1, Name = "USB-C Hub", Price = 1250m, StockQuantity = 12, SupplierName = "TechSupplier", IsAvailable = true, CreatedAt = DateTime.Now },

            new Product { ProductId = 6, CategoryId = 2, Name = "Office Chair", Price = 3500m, StockQuantity = 10, SupplierName = "HomeSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 7, CategoryId = 2, Name = "Standing Desk", Price = 8000m, StockQuantity = 3, SupplierName = "HomeSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 8, CategoryId = 2, Name = "Desk Lamp", Price = 650m, StockQuantity = 0, SupplierName = "HomeSupplier", IsAvailable = false, CreatedAt = DateTime.Now },

            new Product { ProductId = 9, CategoryId = 3, Name = "Notebook Pack", Price = 120m, StockQuantity = 100, SupplierName = "PaperSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 10, CategoryId = 3, Name = "Pen Set", Price = 75m, StockQuantity = 200, SupplierName = "PaperSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 11, CategoryId = 3, Name = "Marker Set", Price = 95m, StockQuantity = 80, SupplierName = "PaperSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 12, CategoryId = 3, Name = "Paper Pack A4", Price = 150m, StockQuantity = 60, SupplierName = "PaperSupplier", IsAvailable = true, CreatedAt = DateTime.Now },

            new Product { ProductId = 13, CategoryId = 4, Name = "Backpack", Price = 1200m, StockQuantity = 15, SupplierName = "BagSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 14, CategoryId = 4, Name = "Mouse Pad", Price = 350m, StockQuantity = 25, SupplierName = "BagSupplier", IsAvailable = true, CreatedAt = DateTime.Now },
            new Product { ProductId = 15, CategoryId = 4, Name = "Laptop Sleeve", Price = 500m, StockQuantity = 18, SupplierName = "BagSupplier", IsAvailable = true, CreatedAt = DateTime.Now }
        };


        public Product Create(CreateProductDto dto)
        {
            var product = new Product
            {
                IsAvailable = true,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
                CreatedAt = DateTime.Now,
                Price = dto.Price,
                SupplierName = dto.SupplierName,
                Name = dto.Name,
                ProductId = _products.Count>0 ? _products.Max(i => i.ProductId)+1 : 1
            };
            _products.Add(product);
            return product;
        }

        public void Delete(int id)
        {
            var p = GetByID(id);
            if (p != null)
                _products.Remove(p);
        }

        public List<Product> GetAll() => _products.ToList();


        public Product GetByID(int id)
        {
            var p = _products.FirstOrDefault(x => x.ProductId == id);
            if (p == null) return null;
            return p;
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var product = GetByID(id);
            if (product != null)
            {
                product.SupplierName = dto.SupplierName;
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.CategoryId = dto.CategoryId;
                product.StockQuantity = dto.StockQuantity;
                product.IsAvailable = dto.IsAvailable;
            }
        }



        public List<Product> GetFilteredProducts(
    string? name,
    int? categoryId,
    decimal? minPrice,
    decimal? maxPrice,
    bool? isAvailable,
    bool? onlyLowStock)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            // Advanced
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (minPrice.HasValue) query = query.Where(p => p.Price >= minPrice.Value);
            if (maxPrice.HasValue) query = query.Where(p => p.Price <= maxPrice.Value);

            if (isAvailable.HasValue)
                query = query.Where(p => p.IsAvailable == isAvailable.Value);

            if (onlyLowStock == true)
                query = query.Where(p => p.StockQuantity <= 5);

            return query.ToList();
        }




        public decimal GetTotalStockValue()
    => _products.Sum(p => p.Price * p.StockQuantity);

        public List<Product> GetLowStockProducts()
            => _products.Where(p => p.StockQuantity > 0 && p.StockQuantity <= 5).ToList();

        public List<Product> GetOutOfStockProducts()
            => _products.Where(p => p.StockQuantity == 0 || !p.IsAvailable).ToList();

        public object GetCategoryReport()
        {
            return _products.GroupBy(p => p.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key,
                    ProductCount = g.Count(),
                    TotalValue = g.Sum(p => p.Price * p.StockQuantity)
                }).ToList();    
        }
    }
}
