using AutoMapper;
using GradeBook.Models.Read;
using GradeBook.Models.Write;
using GradeBook.DataAccess.Entities;
using GradeBook.Models.Auth;

namespace GradeBook.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, PupilModel>()
                .ForMember(p => p.Birthday, opt => opt.MapFrom(p => p.Birthday.ToString("dd/MM/yyyy")))
                .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.LastName));
            CreateMap<UpdatePupil, UserClass>();

            CreateMap<CreateClass, Class>();
            CreateMap<Class, ClassModel>()
                .ForMember(c => c.PupilQuantity, opt => opt.MapFrom(c => c.Pupils.Count));

            CreateMap<CreateSubject, Subject>();
            CreateMap<Subject, SubjectModel>();

            CreateMap<CreateLesson, Lesson>();
            CreateMap<Lesson, LessonModel>()
                .ForMember(l => l.TeacherName, opt => opt.MapFrom(l => l.Teacher.ToString()))
                .ForMember(l => l.Date, opt => opt.MapFrom(l => l.Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateGrade, Grade>();
            CreateMap<UpdateGrade, Grade>();
            CreateMap<Grade, GradeModel>()
                .ForMember(g => g.PupilName, opt => opt.MapFrom(g => g.Pupil.ToString()))
                .ForMember(g => g.SubjectName, opt => opt.MapFrom(g => g.Lesson.Subject.Name))
                .ForMember(g => g.Date, opt => opt.MapFrom(g => g.Lesson.Date.ToString("dd/MM/yyyy")))
                .ForMember(g => g.TeacherName, opt => opt.MapFrom(g => g.Lesson.Teacher.ToString()));

            CreateMap<RegisterUser, ApplicationUser>();
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(u => u.Name, opt => opt.MapFrom(u => u.FirstName + " " + u.LastName));
        }
    }
}
