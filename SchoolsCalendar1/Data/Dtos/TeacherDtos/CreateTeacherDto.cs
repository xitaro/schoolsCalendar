using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Data.Dtos.TeacherDtos
{
    public class CreateTeacherDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
