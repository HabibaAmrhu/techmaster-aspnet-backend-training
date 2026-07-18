using StudentManagementAPI.DTOs;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {
        Student?Create(CreateStudentDTO dto);
        List<Student> GetAll(string? keyword , string? TrackName, bool? isactive , int pageNum = 1 , int PageSize= 10);
        
        Student GetById(int id);
        Student Update(int id,UpdateStudentDTO dto);
        Student UpdateStatus(int id, UpdateStudentStatusDTO dto);
        StudentResponseDTO GetStats();

    }
}
