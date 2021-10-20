using AutoMapper;
using GradeBook.API.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace GradeBook.API.Extensions
{
    public static class MapperExtension
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => 
                mc.AddProfile(new MapperProfile()));

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
