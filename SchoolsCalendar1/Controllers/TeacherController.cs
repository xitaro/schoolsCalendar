using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Models;
using SchoolsCalendar1.Services;

namespace SchoolsCalendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        //private SchoolsCalendarContext _context;
        // private readonly IMapper _mapper;
        private ITeacherService _teacherService;

        public TeacherController(/*SchoolsCalendarContext context, IMapper mapper*/ ITeacherService teacherService)
        {
            //_context = context;
            //_mapper = mapper;
            _teacherService = teacherService;
        }


        [HttpGet]
        public IEnumerable<Teacher> GetAll()
        {
            return _teacherService.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            /*// Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher != null)
            {
                ReadTeacherDto teacherDto = _mapper.Map<ReadTeacherDto>(teacher);
                return Ok(teacher);
            }*/

            ReadTeacherDto teacher = _teacherService.GetById(id);

            if (teacher != null)
            {
                return Ok(teacher);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTeacherDto teacherDto)
        {
            Teacher teacher = _teacherService.Create(teacherDto);   

            if(teacher !=null)
                return Ok(teacher);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTeacherDto teacherDto)
        {
            Teacher teacher = _teacherService.Update(id, teacherDto);

            if(teacher == null)
                NotFound();
            

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Teacher teacher = _teacherService.Delete(id);

            if (teacher == null)
                NotFound();
           
            return NoContent();
        }
    }
}
