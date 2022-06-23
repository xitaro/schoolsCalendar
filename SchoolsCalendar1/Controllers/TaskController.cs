using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.TaskDtos;

namespace SchoolsCalendar1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private SchoolsCalendarContext _context;
        private readonly IMapper _mapper;

        public TaskController(SchoolsCalendarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<Models.Task> GetAll()
        {
            return _context.Tasks;
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Models.Task task = _context.Tasks.FirstOrDefault(myEvent => myEvent.Id == id);

            if (task != null)
            {
                ReadTaskDto taskDto = _mapper.Map<ReadTaskDto>(task);
                return Ok(task);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskDto dto)
        {
            Models.Task task = _mapper.Map<Models.Task>(dto);

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTaskDto dto)
        {
            Models.Task task = _context.Tasks.FirstOrDefault(task => task.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, task);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Models.Task task = _context.Tasks.FirstOrDefault(task => task.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            _context.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

