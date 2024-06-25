using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models.ExpenseDTOs;
using Core.Request.ExpenseModels;

namespace Infrastructure.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseService(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task<string> Add(CreateExpenseModel model)
    {
        return await _expenseRepository.Add(model);
    }


    public async Task<ExpenseDTO> GetById(int id)
    {
        return await _expenseRepository.GetById(id);
    }

    public async Task<ListViewExpenseDTO> GetFiltered(FilterExpenseModel filter)
    {
        return await _expenseRepository.GetFiltered(filter);
    }

    public async Task<string> Update(UpdateExpenseModel model)
    {
        return await _expenseRepository.Update(model);
    }
    public async Task<bool> Delete(int id)
    {
        return await _expenseRepository.Delete(id);
    }
}