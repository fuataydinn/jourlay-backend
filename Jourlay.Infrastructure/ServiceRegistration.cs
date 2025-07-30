using Jourlay.Domain.Common.Mediatr;
using Jourlay.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jourlay.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Custom Mediator Registration
        services.AddScoped<IMediator, Mediator>();

        // Infrastructure servislerini buraya ekleyebilirsiniz
        // Örneğin: Email services, File services, External API services vb.

        // Örnek servisler:
        // services.AddScoped<IEmailService, EmailService>();
        // services.AddScoped<IFileService, FileService>();
        return services;
    }

    public static IServiceCollection AddJourlayMediator(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddSingleton<IMediator, Mediator>();

        if (assemblies?.Length > 0)
        {
            services.AddHandlersFromAssemblies(assemblies);
        }

        return services;
    }

    public static IServiceCollection AddHandlersFromAssemblies(this IServiceCollection services, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            RegisterHandlers(services, assembly);
        }

        return services;
    }

    private static void RegisterHandlers(IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .ToArray();

        // Register Request Handlers
        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .ToArray();

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, type);
            }
        }

        // Register Notification Handlers
        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))
                .ToArray();

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, type);
            }
        }
    }
}
