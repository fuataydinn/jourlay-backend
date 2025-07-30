using Microsoft.EntityFrameworkCore;

namespace Jourlay.Application.Interfaces.Context;

public class BaseContext<TContext>(DbContextOptions<TContext> options) : DbContext(options) where TContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }
}
