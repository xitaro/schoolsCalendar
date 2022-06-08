using SchoolsCalendar1.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Data.Dtos.TeacherDtos
{
    public class ReadTeacherDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
