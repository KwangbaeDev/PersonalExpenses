using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Request;

namespace Infrastructure.Services;

public class ExpenseCategoryService : IExpenseCategoryService
{
    private readonly IExpenseCategoryRepository _expenseCategoryRepository;

    public ExpenseCategoryService(IExpenseCategoryRepository expenseCategoryRepository)
    {
        _expenseCategoryRepository = expenseCategoryRepository;
    }

    public async Task<string> Add(CreateExpenseCategoryModel model)
    {
        return await _expenseCategoryRepository.Add(model);
    }


    public async Task<ExpenseCategoryDTO> GetById(int id)
    {
        return await _expenseCategoryRepository.GetById(id);
    }

    public async Task<ListViewExpenseCategoryDTO> GetFiltered(FilterExpenseCategoryModel filter)
    {
        return  await _expenseCategoryRepository.GetFiltered(filter);
    }

    public async Task<string> Update(UpdateExpenseCategoryModel model)
    {
        return await _expenseCategoryRepository.Update(model);
    }
    public async Task<bool> Delete(int id)
    {
        return await _expenseCategoryRepository.Delete(id);
    }
}