using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private SchoolsCalendarContext _context;
        private readonly IMapper _mapper;

        public StudentController(SchoolsCalendarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);

            if (student != null)
            {
                ReadStudentDto studentDto = _mapper.Map<ReadStudentDto>(student);
                return Ok(studentDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDto studentDto)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);

            if(student == null)
            {
                NotFound();
            }

            _mapper.Map(studentDto, student);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                NotFound();
            }
            _context.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
