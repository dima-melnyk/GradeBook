using GradeBook.BusinessLogic.Interfaces;
using GradeBook.BusinessLogic.Services;
using GradeBook.Repository.Interfaces;
using GradeBook.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook.API.Extensions
{
    public static class ServicesConfigurationExtension
    {
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddTransient<IPupilService, PupilService>();
        }
    }
}
