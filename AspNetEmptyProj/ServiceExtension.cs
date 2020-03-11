using AspNetEmptyProj.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions
{
    public static void AddTimeService(this IServiceCollection services)
    {
        services.AddTransient<TimeService>();
    }

    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageSender, EmailSender>();
        return services;
    }

    public static IServiceCollection AddSmsServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageSender, SmsSender>();
        return services;
    }
}