using System.ComponentModel.DataAnnotations;

namespace WebAPIproject.DTOs
{

    public class Notes
    {
        [Required]
        public string title { get; set; }
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime CreatedDate { get; set; }
    }


    public class CreateNoteRequestDto
    {     

        [Required]
        public string title { get; set; }
        public string content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
