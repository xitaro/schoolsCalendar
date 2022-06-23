using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
