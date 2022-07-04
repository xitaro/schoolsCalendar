using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;
using SchoolsCalendar1.Services;

namespace SchoolsCalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private SchoolsCalendarContext _context;
        // private readonly IMapper _mapper;
        private IStudentService _studentService;

        public StudentController(/*SchoolsCalendarContext context, IMapper mapper*/ IStudentService studentService)
        {
            //_context = context;
            //_mapper = mapper;
            _studentService = studentService;
        }


        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _studentService.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            /*// Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Student Student = _context.Students.FirstOrDefault(Student => Student.Id == id);

            if (Student != null)
            {
                ReadStudentDto StudentDto = _mapper.Map<ReadStudentDto>(Student);
                return Ok(Student);
            }*/

            ReadStudentDto student = _studentService.GetById(id);

            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDto studentDto)
        {
            Student student = _studentService.Create(studentDto);

            if (student != null)
                return Ok(student);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDto studentDto)
        {
            Student student = _studentService.Update(id, studentDto);

            if (student == null)
                NotFound();


            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _studentService.Delete(id);

            if (student == null)
                NotFound();

            return NoContent();
        }
    }
}
