using AspNetLesson.DbRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetLesson
{
    public class Startup
    {
        private string ConString => Configuration.GetConnectionString("DefaultConnection");

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IMessageSender, EmailMessageSender>();
            //services.AddTransient<MessageService>();
            //services.AddMessageService(); DiExtension
            services.AddDbContext<MobileContext>(options => options.UseSqlServer(ConString));
            services.AddControllersWithViews();
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

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapAreaControllerRoute(
                        areaName: "Admin", 
                        name: "adminArea",
                        pattern: "admin/{controller=Admin}/{action=Index}/{id?}");

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }
}
