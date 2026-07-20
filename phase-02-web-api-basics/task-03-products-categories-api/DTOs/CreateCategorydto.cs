using ServiceStack.DataAnnotations;

namespace ProductsCatigoriesAPI.DTOs
{
    public class CreateCategorydto
    {
        [Unique, Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
