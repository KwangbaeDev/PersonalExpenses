using Core.Entities;

namespace Core.Interfaces.Services;

public interface IGenericService<T> where T : BaseEntity
{
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}