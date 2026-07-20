using ProductsCatigoriesAPI.DTOs;
using ProductsCatigoriesAPI.Models;

namespace ProductsCatigoriesAPI.Repositories.Interfaces
{
    public interface ICategory
    {
        List<Category> GetAll();
        Category Create(CreateCategorydto category);
        void Delete(int id);
        void Update(int id, UpdateCatDTO dto);
        Category GetByID(int id);
    }
}
