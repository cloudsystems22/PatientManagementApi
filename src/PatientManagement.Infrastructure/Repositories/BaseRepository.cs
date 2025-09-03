using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PatientManagement.Domain.Interfaces.Repositories;
using PatientManagement.Infrastructure.Data;

namespace PatientManagement.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly MSSQLDbContext _context;
    private readonly ILogger<BaseRepository<TEntity>> _logger;
    public BaseRepository(MSSQLDbContext context, ILogger<BaseRepository<TEntity>> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task AddAsync(TEntity obj)
    {
        await Task.Run(() =>
        {
            try
            {
                _context.Set<TEntity>().Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao inserir um novo registro. @{Message}", ex.Message);
                throw new Exception($"Erro ao inserir um novo registro. {ex.Message}");
            }
        });
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Task.Run(() => _context.Set<TEntity>().ToList());
    }

    public async Task<IEnumerable<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Task.Run(() => _context.Set<TEntity>().Where(expression).ToList());
    }

    public async Task<TEntity> GetByIdAsync(string uid)
    {
        return await Task.Run(() => _context.Set<TEntity>().Find(uid)!);
    }

    public async Task RemoveAsync(TEntity obj)
    {
        await Task.Run(() =>
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao tentar remover registro. @{Message}", ex.Message);
                throw new Exception($"Erro ao tentar remover registro. {ex.Message}");
            }
        });
    }
    
    public async Task UpdateAsync(TEntity obj)
    {
        await Task.Run(() =>
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao tentar atualizar um registro. @{Message}", ex.Message);
                throw new Exception($"Erro ao tentar atualizar um registro. {ex.Message}");
            }
        });
    }
}