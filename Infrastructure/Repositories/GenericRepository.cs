using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly PersonalExpensesContext _context;

    public GenericRepository(PersonalExpensesContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}