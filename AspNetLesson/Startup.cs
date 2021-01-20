using AspNetLesson.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddleWareExtension;

namespace AspNetLesson
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment _env)
        {
            if (_env.IsEnvironment("Test"))
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Application in testing stage");
                });
            }
            else
            {
                if (_env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                //app.UseDefaultFiles();
                //app.UseDirectoryBrowser();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                //app.UseMiddleware<ErrorHandlingMiddleware>();
                //app.UseMiddleware<AuthenticationMiddleware>();
                //app.UseMiddleware<RoutingMiddlware>();
                //app.UseToken("555");
                app.UseRouting();

                //app.UseEndpoints(endpoints =>
                //{
                //    endpoints.MapGet("/", async context =>
                //    {
                //        await context.Response.WriteAsync("Hello World!");
                //    });
                //});
            }
        }
    }
}
