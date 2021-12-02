using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GradeBook.API.Extensions
{
    public static class ServicesConfigurationExtension
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IPupilService, PupilService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAdminService, AdminService>();
        }
    }
}
