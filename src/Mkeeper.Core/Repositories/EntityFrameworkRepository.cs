using Mkeeper.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Mkeeper.Db.Entities;

namespace Mkeeper.Core.Repositories;

public class EntityFrameworkRepository<T> : IAsyncRepository<T>
    where T : BaseEntity
{
    private readonly MkeeperContext _context;

    public EntityFrameworkRepository(MkeeperContext context)
        => _context = context;

    public ValueTask<T?> GetByIdAsync(int id)
        => _context.Set<T>().FindAsync(id);

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        => _context.Set<T>().FirstOrDefaultAsync(predicate);

    public void Add(T entity)
        => _context.Set<T>().Add(entity);

    public void Update(T entity)
        => _context.Entry(entity).State = EntityState.Modified;

    public void Remove(T entity)
        => _context.Set<T>().Remove(entity);

    public Task<List<T>> GetAllAsync()
        => _context.Set<T>().ToListAsync();

    public Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        => _context.Set<T>().Where(predicate).ToListAsync();
}
