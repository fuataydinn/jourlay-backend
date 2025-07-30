using Jourlay.Domain.Common.Mediatr;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jourlay.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Handler Registration
        services.AddHandlersFromAssembly(Assembly.GetExecutingAssembly());

        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

    private static IServiceCollection AddHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
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

        return services;
    }
}