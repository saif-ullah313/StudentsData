using StudentsData.Models;
using StudentsData. Services;
using Microsoft.AspNetCore.Mvc;



namespace StudentsData.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("api/Student")]
        public async Task<ActionResult> AddNewStudent([FromBody] Student student)
        {
            var result = await _studentService.AddNewStudent(student);
            if (result > 0)
                return this.Ok("Data Save Successfully");
            else
                throw new Exception("error found.");
        }

        [HttpPut("api/Student/{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] Student student)

        {

            student.Id = id;
            var result = await _studentService.UpdateNewStudent(student);
            if (result > 0)
                return this.Ok("data udpated successfully ");
            else
                throw new Exception("error found.");
        }

        [HttpGet("api/Student/{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetStudentById(id);
            if (result != null)
                return this.Ok(result);
            else
                return this.Ok("student not found...");
        }
        [HttpGet("api/Student")]
        public async Task<ActionResult> GetAllStudents()
        {
            var result = await _studentService.GetAllStudents();
            if (result.Count>0)
                return this.Ok(result);
            else
                return this.Ok("student not found...");
        }

        [HttpDelete("api/Student/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            if (result > 0)
                return this.Ok("record deleted");
            else
                return this.Ok("student not found...");
        }

    }


}

