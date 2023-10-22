using System.Linq.Expressions;

namespace Mkeeper.Core.Repositories;

public interface IAsyncRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
