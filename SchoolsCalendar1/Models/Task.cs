using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        DateTime Date { get; set; }

        }
}
