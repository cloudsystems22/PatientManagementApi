using System.Linq.Expressions;

namespace PatientManagement.Domain.Interfaces.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity obj);
    Task UpdateAsync(TEntity obj);
    Task RemoveAsync(TEntity obj);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetByIdAsync(string uid);
}