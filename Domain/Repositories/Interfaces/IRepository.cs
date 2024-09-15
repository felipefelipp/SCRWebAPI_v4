using System.Linq.Expressions;

namespace Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> Get(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAll();
    Task<T> Create(T entity);
    Task Update(T entity);
    Task Delete(int id);
}
