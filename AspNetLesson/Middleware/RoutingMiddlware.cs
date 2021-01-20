using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetLesson.Middleware
{
    public class RoutingMiddlware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();

            if (path == "/index")
            {
                await context.Response.WriteAsync("Home Page");
            }
            else if (path == "/about")
            {
                await context.Response.WriteAsync("About");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
