using System.ComponentModel.DataAnnotations;

namespace WebAPIproject.DTOs
{
    public class UpdateNoteRequest
    {
        [Required]
        public string title { get; set; }
        public string content { get; set; }
    }
}
