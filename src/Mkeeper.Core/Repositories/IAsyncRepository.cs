using System.Linq.Expressions;

namespace Mkeeper.Core.Repositories;

public interface IAsyncRepository<T>
{

    ValueTask<T?> GetByIdAsync(int id);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);

    Task<List<T>> GetAllAsync();
    Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
}
