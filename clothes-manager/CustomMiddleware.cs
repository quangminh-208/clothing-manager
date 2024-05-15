using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace clothes_manager
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Custom Middleware logic from the separate class.");
            await _next.Invoke(context);
        }
    }
}
