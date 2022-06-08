using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolsCalendar1.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
