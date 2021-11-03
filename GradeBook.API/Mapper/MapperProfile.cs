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
            CreateMap<CreatePupil, Pupil>();
            CreateMap<UpdatePupil, Pupil>();
            CreateMap<Pupil, PupilModel>()
                .ForMember(p => p.ClassName, opt => opt.MapFrom(p => p.Class.Name))
                .ForMember(p => p.Birthday, opt => opt.MapFrom(p => p.ApplicationUser.Birthday.ToString("dd/MM/yyyy")))
                .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.ApplicationUser.FirstName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.ApplicationUser.LastName));

            CreateMap<CreateClass, Class>();
            CreateMap<Class, ClassModel>()
                .ForMember(c => c.PupilQuantity, opt => opt.MapFrom(c => c.Pupils.Count));

            CreateMap<CreateSubject, Subject>();

            CreateMap<CreateTeacher, Teacher>();
            CreateMap<Teacher, TeacherModel>()
                .ForMember(t => t.Birthday, opt => opt.MapFrom(t => t.ApplicationUser.Birthday.Date.ToString("dd/MM/yyyy")))
                .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.ApplicationUser.FirstName))
                .ForMember(t => t.LastName, opt => opt.MapFrom(t => t.ApplicationUser.LastName));


            CreateMap<CreateLesson, Lesson>();
            CreateMap<Lesson, LessonModel>()
                .ForMember(l => l.TeacherName, opt =>
                    opt.MapFrom(l => l.Teacher.ApplicationUser.FirstName + " " + l.Teacher.ApplicationUser.LastName))
                .ForMember(l => l.Date, opt => opt.MapFrom(l => l.Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateGrade, Grade>();
            CreateMap<UpdateGrade, Grade>();
            CreateMap<Grade, GradeModel>()
                .ForMember(g => g.PupilName, opt =>
                    opt.MapFrom(g => g.Pupil.ApplicationUser.FirstName + " " + g.Pupil.ApplicationUser.LastName))
                .ForMember(g => g.SubjectName, opt => opt.MapFrom(g => g.Lesson.Subject.Name))
                .ForMember(g => g.Date, opt => opt.MapFrom(g => g.Lesson.Date.ToString("dd/MM/yyyy")))
                .ForMember(g => g.TeacherName, opt =>
                    opt.MapFrom(g => g.Lesson.Teacher.ApplicationUser.FirstName + " " + g.Lesson.Teacher.ApplicationUser.LastName));

            CreateMap<RegisterUser, ApplicationUser>();
            CreateMap<ApplicationUser, UserModel>()
                .ForMember(u => u.Name, opt => opt.MapFrom(u => u.FirstName + " " + u.LastName));
        }
    }
}
