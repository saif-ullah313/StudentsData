using StudentsData.Context;
using StudentsData.Models;
using Dapper;

namespace StudentsData.Services
{
    public class StudentService : IStudentService
    {
        private readonly DapperContext _context;
        public StudentService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewStudent(Student student)
        {

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StdName", student.StdName);
                parameters.Add("@PhoneNo", student.PhoneNo);
                parameters.Add("@City", student.City);
                var result = await connection.ExecuteAsync("insertStudentInfo", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateNewStudent(Student student)
        {

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StdName", student.StdName);
                parameters.Add("@PhoneNo", student.PhoneNo);
                parameters.Add("@City", student.City);
                parameters.Add("@Id", student.Id);
                var result = await connection.ExecuteAsync("UpdateStudentInfo", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<int> DeleteStudent(int Id)
        {

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", Id);

                var result = await connection.ExecuteAsync("DeleteStudent", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<Student> GetStudentById(int id)
        {

            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                var result = await connection.QueryAsync<Student>("GetStudentById", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        public async Task<List<Student>> GetAllStudents()
        {

            using (var connection = _context.CreateConnection())
            {


                var result = await connection.QueryAsync<Student>("GetAllStudents", null, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
