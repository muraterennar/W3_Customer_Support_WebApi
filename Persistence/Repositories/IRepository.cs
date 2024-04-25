using Core.Entities;

namespace Persistence.Repositories;

public interface IRepository<T> where T : Entity<int>
{
    Task<List<T>> GetAll(string query);
    Task<T> GetByAny(string query);
    Task<T> Add(T entity, string query);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}
