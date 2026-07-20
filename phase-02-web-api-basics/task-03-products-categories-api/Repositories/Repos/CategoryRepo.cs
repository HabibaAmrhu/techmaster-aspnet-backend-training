using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Models;
using ProductsCatigoriesAPI.Repositories.Interfaces;

namespace ProductsCatigoriesAPI.Repositories.GenericRepos
{
    public class CategoryRepo : ICategory
    {
        private static readonly List<Category> _categories = new List<Category>
        {
            new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and Gadgets", IsActive = true, CreatedAt = DateTime.Now },
            new Category { CategoryId = 2, Name = "Furniture", Description = "Office and Home Furniture", IsActive = true, CreatedAt = DateTime.Now },
            new Category { CategoryId = 3, Name = "Stationery", Description = "Pens, Notebooks and Paper", IsActive = true, CreatedAt = DateTime.Now },
            new Category { CategoryId = 4, Name = "Accessories", Description = "Computer and Laptop Accessories", IsActive = true, CreatedAt = DateTime.Now }
        };
        public Category Create(CreateCategorydto dto)
        {
            var c = new Category
            {
                CategoryId = _categories.Count > 0 ? _categories.Max(x => x.CategoryId)+1 : 1,
                Name = dto.Name,
                CreatedAt = DateTime.Now,
                Description = dto.Description,
                IsActive = true
            };
            _categories.Add(c);
            return c;

        }

        public void Delete(int id)
        {
            var cat = GetByID(id);
            if (cat != null) 
            _categories.Remove(cat);
        }

        public List<Category> GetAll()
        => _categories.ToList();

        public Category GetByID(int id)
        =>
             _categories.FirstOrDefault(x=>x.CategoryId == id);

        public void Update(int id, UpdateCatDTO dto)
        {
            var category = GetByID(id);
            if (category != null)
            {
                category.Name = dto.Name;
                category.Description = dto.Description;
                category.IsActive = dto.IsActive;
            }
        }
    }
}
