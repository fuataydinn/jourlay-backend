using Jourlay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jourlay.Application.Interfaces.Context;

public interface IApplicationDbContext
{
    DbSet<ContactUsEntity> ContactUses { get; set; }
    DbSet<OfficeInfoEntity> OfficeInfos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
