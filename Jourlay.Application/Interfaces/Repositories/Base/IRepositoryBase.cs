using Jourlay.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Jourlay.Application.Interfaces.Repositories.Base;

public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
{
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask<bool> DeleteByIdAsync(Guid id);
    ValueTask<IEnumerable<TEntity>> GetAllAsync();
    ValueTask<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<TEntity> GetByIdAsync(Guid id);
    ValueTask<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression = null);
}
