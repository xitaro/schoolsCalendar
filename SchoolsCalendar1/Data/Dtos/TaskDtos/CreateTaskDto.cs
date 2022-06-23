using System.ComponentModel.DataAnnotations;

namespace SchoolsCalendar1.Data.Dtos.TaskDtos
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo data é obrigatório")]
        public DateTime Date { get; set; }
    }
}
