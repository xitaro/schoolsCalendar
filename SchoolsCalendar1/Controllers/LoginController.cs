using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Services;
using Newtonsoft.Json;
using System.Text.Json;

namespace SchoolsCalendar1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ITeacherService _teacherService;
        private IStudentService _studentService;

        public LoginController(ITeacherService teacherService, IStudentService studentService)
        { 
            _teacherService = teacherService;
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult Login(JsonElement json)
        {
            string email = json.GetProperty("email").ToString();
            string password = json.GetProperty("password").ToString();
            bool isTeacher = json.GetProperty("isTeacher").GetBoolean();

            if (isTeacher)
            {
                ReadTeacherDto teacherDto = _teacherService.GetByLogin(email, password);

                if (teacherDto != null)
                {
                    return Ok(teacherDto);
                }
            }
            else
            {
                ReadStudentDto studentDto = _studentService.GetByLogin(email, password);

                if (studentDto != null)
                {
                    return Ok(studentDto);
                }
            }

            return NotFound();
        }
    }
}
