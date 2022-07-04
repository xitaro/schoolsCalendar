using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        ReadStudentDto GetById(int id);
        ReadStudentDto GetByLogin(string email, string password);
        Student Create(CreateStudentDto studentDto);
        Student Update(int id, UpdateStudentDto studentDto);
        Student Delete(int id);
    }
}
