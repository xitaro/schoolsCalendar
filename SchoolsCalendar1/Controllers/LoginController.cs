using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data.Dtos;
using SchoolsCalendar1.Services;

namespace SchoolsCalendar1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpPost("/student")]
        public IActionResult StudentLogin(LoginDto dto)
        {
            if (_loginService.CheckStudentLogin(dto))
            {
                return Ok();
            }

            return BadRequest();
            
        }

        [HttpPost("/teacher")]
        public IActionResult TeacherLogin(LoginDto dto)
        {
            if (_loginService.CheckTeacherLogin(dto))
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
