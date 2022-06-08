using AutoMapper;
using SchoolsCalendar1.Data.Dtos.StudentDtos;
using SchoolsCalendar1.Models;

namespace SchoolsCalendar1.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Student, ReadStudentDto>();
        }
    }
}
