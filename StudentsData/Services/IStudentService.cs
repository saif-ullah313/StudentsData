using StudentsData.Models;

namespace StudentsData.Services
{
    public interface IStudentService
    {
   
    
        Task<int> AddNewStudent(Student student);
        Task<int> UpdateNewStudent(Student student);
        Task<int> DeleteStudent(int Id);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetAllStudents();
    
}
    }

