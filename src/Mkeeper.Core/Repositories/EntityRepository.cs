using Mkeeper.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Mkeeper.Db.Entities;
using Mkeeper.Db.Entities.Abstract;

namespace Mkeeper.Core.Repositories;

public class Repository<T> : IAsyncRepository<T>
    where T : BaseEntity
{
    private readonly MkeeperContext _context;

    public Repository(MkeeperContext context)
        => _context = context;

    public void Add(T entity)
        => _context.Add(entity);

    public void Update(T entity)
        => _context.Entry(entity).State = EntityState.Modified;

    public void Remove(T entity)
        => _context.Remove(entity);

    public Task<List<T>> GetAllAsync()
        => _context.Set<T>().ToListAsync();

    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        => _context.Set<T>().FirstOrDefaultAsync(predicate);

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => _context.Set<T>().Where(predicate).ToListAsync();
}
