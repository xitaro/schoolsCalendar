using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
