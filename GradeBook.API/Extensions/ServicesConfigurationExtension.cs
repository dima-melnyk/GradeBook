using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Services;
using GradeBook.Repository.Interfaces;
using GradeBook.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GradeBook.API.Extensions
{
    public static class ServicesConfigurationExtension
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddTransient<IPupilService, PupilService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ITeacherManager, TeacherManager>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}
