namespace Jewelry.Data.Repository.IRepository;

using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    T Get(Expression<Func<T, bool>> filter, string includeProperties = null, bool tracked = false);

    IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null);

    void Add(T entity);

    void Remove(T entity);

    void RemoveRange(IEnumerable<T> entities);

    void Save();
}
