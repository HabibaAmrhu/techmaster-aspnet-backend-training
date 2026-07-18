using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = ServiceStack.DataAnnotations.RequiredAttribute;

namespace StudentManagementAPI.DTOs
{
    public class CreateStudentDTO
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress , Unique]
        public string email { get; set; }
        [Required , Phone]
        public string phoneNumber { get; set; }
        [Required]
        public string TrackName { get; set; }
        public DateTime EnrollmentDate { get; set; }
       
    }
}
