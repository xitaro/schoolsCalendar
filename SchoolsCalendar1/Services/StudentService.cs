using AutoMapper;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Services
{
    public class StudentService : IStudentService
    {
        private SchoolsCalendarContext _context;
        private readonly IMapper _mapper;

        public StudentService(SchoolsCalendarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public ReadStudentDto GetById(int id)
        {
            // Retorna da lista de eventos o primeiro elemento que encontrar, onde o elemento é um Evento, e seu Id tem que ser igual ao passado pelo parâmetro
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);

            if (student != null)
            {
                ReadStudentDto studentDto = _mapper.Map<ReadStudentDto>(student);
                return (studentDto);
            }
            return null;
        }

        public ReadStudentDto GetByLogin(string email, string password)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Email == email && student.Password == password);

            if (student != null)
            {
                ReadStudentDto studentDto = _mapper.Map<ReadStudentDto>(student);
                return (studentDto);
            }

            return null;
        }

        public Student Create(CreateStudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            return (student);
        }

        public Student Update(int id, UpdateStudentDto studentDto)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);

            if (student == null)
                return null;

            _mapper.Map(studentDto, student);

            _context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);

            if (student == null)
            {
                return null;
            }
            _context.Remove(student);
            _context.SaveChanges();
            return student;
        }
    }
}

