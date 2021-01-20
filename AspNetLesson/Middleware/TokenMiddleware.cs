using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetLesson.Middleware
{
    public class TokenMiddleware
    {
        private readonly string _token;
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next, string token)
        {
            _next = next;
            _token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (token != _token)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
