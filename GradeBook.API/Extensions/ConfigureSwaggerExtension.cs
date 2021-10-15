using Microsoft.AspNetCore.Builder;

namespace GradeBook.API.Extensions
{
    public static class ConfigureSwaggerExtension
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GradeBook.API v1"));
        }
    }
}
