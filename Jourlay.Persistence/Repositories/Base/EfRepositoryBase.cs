using Jourlay.Application.Interfaces.Repositories.Base;
using Jourlay.Application.Utilities.Extensions;
using Jourlay.Domain.Entities.Common;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class EfRepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : BaseEntity
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public EfRepositoryBase(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);

        bool added = await SaveChangesAsync();

        if (added)
            return entity;

        return null;
    }
    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;

        _dbSet.Update(entity);

        bool updated = await SaveChangesAsync();

        if (updated)
            return entity;

        return null;
    }
    public async ValueTask<bool> DeleteByIdAsync(Guid id)
    {
        var affected = await _dbSet
            .Where(x => x.Id == id && !x.IsDeleted)
            .ExecuteUpdateAsync(x => x
            .SetProperty(i => i.IsDeleted, true)
            .SetProperty(u => u.UpdatedAt, DateTime.Now));

        return affected >= 1;
    }

    public async ValueTask<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().Where(x => !x.IsDeleted).ToListAsync();
    }
    public async ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AsNoTracking().AnyAsync(expression.AndAlso(x => !x.IsDeleted));
    }
    public async ValueTask<TEntity> GetByIdAsync(Guid id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }
    public async ValueTask<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression = null)
    {
        IQueryable<TEntity> data;

        if (expression.IsNull())
        {
            data = await ValueTask.FromResult(_dbSet.AsNoTracking().Where(x => !x.IsDeleted));
        }
        else
        {
            data = await ValueTask.FromResult(_dbSet.AsNoTracking().Where(expression.AndAlso(x => !x.IsDeleted)));
        }

        if (data is null)
            return [];

        return data;
    }

    public async ValueTask<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression.AndAlso(x => !x.IsDeleted));
    }
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() >= 1;

}