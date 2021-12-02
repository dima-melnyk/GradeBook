using GradeBook.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace GradeBook.API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseErrorHandler(this IApplicationBuilder app) => app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}
