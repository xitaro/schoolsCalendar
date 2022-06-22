using SchoolsCalendar1.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Data.Dtos.StudentDtos
{
    public class ReadTaskDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }

        [Required]
        DateTime Date { get; set; }
    }
}
