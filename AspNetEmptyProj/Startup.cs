using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetEmptyProj.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetEmptyProj
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddTransient<IMessageSender, SmsSender>(); // Dependancy Injection, Service 
            services.AddTransient<MessageService>();
            services.AddTimeService(); // services.AddTransient<TimeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageService messageService)
        {
            //app.UseMiddleware<ErrorHandlingMiddleware>();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<RoutingMiddleware>();

            //app.UseDirectoryBrowser(); // exploreing cataloges of application
            //app.UseStaticFiles(); // https://localhost:44351/index.html

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync($"CurrentTime: {timeService?.GetTime()}");
                await context.Response.WriteAsync(messageService.Send());
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
