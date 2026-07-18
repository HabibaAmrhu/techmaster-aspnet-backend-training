namespace StudentManagementAPI.DTOs
{
    public class StudentResponseDTO
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int InactiveStudents { get; set; }
        public List<TrackStat> CountByTrack { get; set; }
    }

    public class TrackStat
    {
        public string TrackName { get; set; }
        public int Count { get; set; }
    }
}
