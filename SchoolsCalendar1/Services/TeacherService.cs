using AutoMapper;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Services
{
    public class TeacherService : ITeacherService
    {
        private SchoolsCalendarContext _context;
        private readonly IMapper _mapper;

        public TeacherService(SchoolsCalendarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers;
        }

        public ReadTeacherDto GetById(int id)
        {
            // Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher != null)
            {
                ReadTeacherDto teacherDto = _mapper.Map<ReadTeacherDto>(teacher);
                return (teacherDto);
            }
            return null;
        }

        public ReadTeacherDto GetByLogin(string email, string password)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Email == email && teacher.Password == password);

            if (teacher != null)
            {
                ReadTeacherDto teacherDto = _mapper.Map<ReadTeacherDto>(teacher);
                return (teacherDto);
            }

            return null;
        }

        public Teacher Create(CreateTeacherDto teacherDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherDto);

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return (teacher);
        }

        public Teacher Update(int id, UpdateTeacherDto teacherDto)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher == null)
                return null;

            _mapper.Map(teacherDto, teacher);

            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(int id)
        {
            Teacher teacher = _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);

            if (teacher == null)
            {
                return null;
            }
            _context.Remove(teacher);
            _context.SaveChanges();
            return teacher;
        }
    }
}

