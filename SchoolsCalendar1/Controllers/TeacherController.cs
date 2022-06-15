using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private SchoolsCalendarContext _context;
        private readonly IMapper _mapper;

        public TeacherController(SchoolsCalendarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher != null)
            {
                ReadTeacherDto teacherDto = _mapper.Map<ReadTeacherDto>(teacher);
                return Ok(teacher);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTeacherDto teacherDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherDto);

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTeacherDto teacherDto)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if(teacher == null)
            {
                NotFound();
            }

            _mapper.Map(teacherDto, teacher);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            _context.Remove(teacher);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
