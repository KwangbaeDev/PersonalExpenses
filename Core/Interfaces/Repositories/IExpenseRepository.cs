using Core.Models.ExpenseDTOs;
using Core.Request.ExpenseModels;

namespace Core.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task<string> Add(CreateExpenseModel model);
    Task<ExpenseDTO> GetById(int id);
    Task<ListViewExpenseDTO> GetFiltered(FilterExpenseModel filter);
    Task<string> Update(UpdateExpenseModel model);
    Task<bool> Delete(int id);
}