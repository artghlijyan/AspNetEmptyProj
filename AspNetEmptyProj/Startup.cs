using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetEmptyProj
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();

            app.UseDirectoryBrowser(); // exploreing cataloges of application
            app.UseStaticFiles(); // https://localhost:44351/index.html

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}
    }
}
