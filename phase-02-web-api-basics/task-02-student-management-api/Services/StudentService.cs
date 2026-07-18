using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly static List<Student> _students = new List<Student>();



        public Student? Create(CreateStudentDTO dto)
        {
            if (_students.Any(s => s.email.Equals(dto.email, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            var student = new Student
            {
                email = dto.email,
                Id = _students.Count >0 ? _students.Max(i => i.Id)+1 : 1,
                EnrollmentDate = DateTime.Now,
                Name = dto.Name,
                phoneNumber = dto.phoneNumber,
                TrackName = dto.TrackName,
            };

            _students.Add(student);
            return student;
        }

        public List<Student> GetAll(string keyword, string TrackName, bool? isactive, int pageNum = 1, int PageSize = 10)
        {
            // Advanced for me
            var query = _students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
               query= query.Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || s.email.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            }

            if (!string.IsNullOrWhiteSpace(TrackName) && TrackName != "TrackName" && TrackName != "string")
            {
                query = query.Where(t => t.TrackName.Contains(TrackName, StringComparison.OrdinalIgnoreCase));
            }

            if (isactive.HasValue)
            {
                query = query.Where(t => t.IsActive == isactive.Value);
            }

            var students = query.Skip((pageNum - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return students;
        }

        public Student GetById(int id)=>
        
            _students.FirstOrDefault(s => s.Id == id);

        public StudentResponseDTO GetStats()
        {
            return new StudentResponseDTO
            {
                TotalStudents = _students.Count,
                ActiveStudents = _students.Where(s => s.IsActive).Count(),
                InactiveStudents = _students.Where(s => s.IsActive == false).Count(),
                CountByTrack = _students.GroupBy(s => s.TrackName)
                .Select(
                    g => new TrackStat
                    {
                        Count = g.Count(),
                        TrackName = g.Key,
                    }
                ).ToList()
            };
        }

        public Student Update(int  id ,UpdateStudentDTO dto)
        {
            var s =  GetById(id);
            if (s == null) { return null; }
            s.Name = dto.Name;
            s.email = dto.email;
            s.phoneNumber = dto.phoneNumber;
            s.TrackName = dto.TrackName;

            return s;
        }

        public Student UpdateStatus(int id, UpdateStudentStatusDTO dto)
        {
            var s = GetById(id);
            if (s == null) { return null; }
            s.IsActive = dto.IsActive;
            return s;
        }
    }
}
