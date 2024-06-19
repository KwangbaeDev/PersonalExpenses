using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Remove(int id);
}