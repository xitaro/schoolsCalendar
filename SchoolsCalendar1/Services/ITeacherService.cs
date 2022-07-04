using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Services
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        ReadTeacherDto GetById(int id);
        ReadTeacherDto GetByLogin(string email, string password);
        Teacher Create(CreateTeacherDto teacherDto);
        Teacher Update(int id, UpdateTeacherDto teacherDto);
        Teacher Delete(int id);
    }
}
