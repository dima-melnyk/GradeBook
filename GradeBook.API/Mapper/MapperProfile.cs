using AutoMapper;
using GradeBook.API.Models;
using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;

namespace GradeBook.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreatePupil, Pupil>();
            CreateMap<UpdatePupil, Pupil>();
            CreateMap<Pupil, PupilToView>()
                .ForMember(p => p.ClassName, opt => opt.MapFrom(p => p.Class.Name))
                .ForMember(p => p.Birthday, opt => opt.MapFrom(p => p.Birthday.Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateClass, Class>();
            CreateMap<Class, ClassToView>()
                .ForMember(c => c.PupilQuantity, opt => opt.MapFrom(c => c.Pupils.Count));

            CreateMap<CreateSubject, Subject>();

            CreateMap<CreateTeacher, Teacher>();
            CreateMap<Teacher, TeacherToView>()
                .ForMember(t => t.Birthday, opt => opt.MapFrom(t => t.Birthday.Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateLesson, Lesson>();
            CreateMap<Lesson, LessonToView>()
                .ForMember(l => l.TeacherName, opt => opt.MapFrom(l => l.Teacher.FirstName + " " + l.Teacher.LastName))
                .ForMember(l => l.Date, opt => opt.MapFrom(l => l.Date.Date.ToString("dd/MM/yyyy")));

            CreateMap<CreateGrade, Grade>();
            CreateMap<UpdateGrade, Grade>();
            CreateMap<Grade, GradeToView>()
                .ForMember(g => g.PupilName, opt => opt.MapFrom(g => g.Pupil.FirstName + " " + g.Pupil.LastName))
                .ForMember(g => g.SubjectName, opt => opt.MapFrom(g => g.Lesson.Subject.Name))
                .ForMember(g => g.Date, opt => opt.MapFrom(g => g.Lesson.Date.Date.ToString("dd/MM/yyyy")));
        }
    }
}
