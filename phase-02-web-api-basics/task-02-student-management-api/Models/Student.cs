namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string TrackName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? GitHubProfileUrl { get; set; }
        public string? LinkedInProfileUrl { get; set; }
    }
}
