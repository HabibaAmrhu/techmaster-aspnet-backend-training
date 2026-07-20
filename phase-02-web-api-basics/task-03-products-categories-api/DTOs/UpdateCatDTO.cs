using ServiceStack.DataAnnotations;

namespace ProductsCatigoriesAPI.DTOs
{
    public class UpdateCatDTO
    {
        [Unique, Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
