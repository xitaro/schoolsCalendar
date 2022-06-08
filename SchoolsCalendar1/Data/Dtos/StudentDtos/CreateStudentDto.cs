using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Data.Dtos.StudentDtos
{
    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
    }
}
