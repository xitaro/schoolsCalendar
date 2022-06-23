using AutoMapper;
using SchoolsCalendar1.Data.Dtos.TaskDtos;

namespace SchoolsCalendar1.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDto, Models.Task>();
            CreateMap<UpdateTaskDto, Models.Task>();
            CreateMap<Models.Task, ReadTaskDto>();        
            
        }

    }
}
