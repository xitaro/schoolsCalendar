using AutoMapper;
using SchoolsCalendar1.Data.Dtos.TeacherDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();
            CreateMap<Teacher, ReadTeacherDto>();
        }
    }
}
