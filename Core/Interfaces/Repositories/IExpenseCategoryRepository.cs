using Core.Models;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface IExpenseCategoryRepository
{
    Task<string> Add(CreateExpenseCategoryModel model);
    Task<ExpenseCategoryDTO> GetById(int id);
    Task<ListViewExpenseCategoryDTO> GetFiltered(FilterExpenseCategoryModel filter);
    Task<string> Update(UpdateExpenseCategoryModel model);
    Task<bool> Delete(int id);
}