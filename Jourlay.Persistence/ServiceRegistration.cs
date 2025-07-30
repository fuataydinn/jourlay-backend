using Jourlay.Application.Interfaces.Context;
using Jourlay.Application.Interfaces.Repositories;
using Jourlay.Application.Interfaces.Repositories.Base;
using Jourlay.Application.Interfaces.Services;
using Jourlay.Persistence.Contexts;
using Jourlay.Persistence.Repositories;
using Jourlay.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jourlay.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        services.AddHttpContextAccessor();


        services.AddScoped(typeof(IRepositoryBase<>), typeof(EfRepositoryBase<>));

        // Specific Repositories
        services.AddScoped<IContactUsRepository, ContactUsRepository>();

        // Services
        services.AddScoped<IContactUsService, ContactUsService>();

        return services;
    }
}
