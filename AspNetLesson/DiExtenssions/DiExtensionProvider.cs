using AspNetLesson.Services;
using AspNetLesson.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetLesson.DiExtenssions
{
    public static class DiExtensionProvider
    {
        public static void AddMessageService(this IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
        }
    }
}
