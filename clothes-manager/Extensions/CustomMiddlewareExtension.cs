using Microsoft.AspNetCore.Builder;

namespace clothes_manager.Extensions
{
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) 
            => app.UseMiddleware<CustomMiddleware>();
    }
}
