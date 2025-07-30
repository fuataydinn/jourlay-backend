using Jourlay.Application.Interfaces.Context;
using Jourlay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jourlay.Persistence.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<ContactUsEntity> ContactUses { get; set; }
    public DbSet<OfficeInfoEntity> OfficeInfos { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Varsa ek konfigürasyonlar
    }
}
