using AutoMapper;
using SchoolsCalendar1.Data;
using SchoolsCalendar1.Data.Dtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Services
{
    public class LoginService
    {
        private SchoolsCalendarContext _context;
        //private readonly IMapper _mapper;

        public LoginService(SchoolsCalendarContext context/*, IMapper mapper*/)
        {
            _context = context;
            //_mapper = mapper;
        }

        public bool CheckTeacherLogin(LoginDto dto)
        {

            var user = _context.Teachers.FirstOrDefault(user => user.Email == dto.Email);

            if (user == null)
            {
                // Email não cadastrado
                return false;

            }

            if (dto.Password != user.Password)
            {
                // Senha errada
                return false;
            }

            return true;
        }

        public bool CheckStudentLogin(LoginDto dto)
        {

            var user = _context.Students.FirstOrDefault(user => user.Email == dto.Email);

            if (user == null)
            {
                // Email não cadastrado
                return false;

            }

            if (dto.Password != user.Password)
            {
                // Senha errada
                return false;
            }

            return true;
        }
    }
}
