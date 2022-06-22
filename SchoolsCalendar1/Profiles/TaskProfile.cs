using AutoMapper;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDto, Models.Task>();
            CreateMap<Models.Task, CreateTaskDto>();

            CreateMap<Models.Task, ReadTaskDto>();
            CreateMap<ReadTaskDto, Models.Task>();

        }
           
    }
}
