using Core.Entities;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Request;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExpenseCategoryRepository : IExpenseCategoryRepository
{
    private readonly PersonalExpensesContext _context;

    public ExpenseCategoryRepository(PersonalExpensesContext context)
    {
        _context = context;
    }

    public async Task<string> Add(CreateExpenseCategoryModel model)
    {
        var createExpenseCategory = model.Adapt<ExpenseCategory>();

        _context.ExpenseCategories.Add(createExpenseCategory);
        await _context.SaveChangesAsync();

        model.Id = createExpenseCategory.Id;

        return $"The category with the id {model.Id} to follow added correctly.";
    }


    public async Task<ExpenseCategoryDTO> GetById(int id)
    {
        var expenseCategory = await _context.ExpenseCategories.FindAsync(id);

        if (expenseCategory == null || expenseCategory.IsDeleted == true)
        {
            throw new NotFoundException($"The category with the id {id} does not exist.");
        }

        var expenseCategoryDTO = expenseCategory.Adapt<ExpenseCategoryDTO>();
        return expenseCategoryDTO;
    }


    public async Task<ListViewExpenseCategoryDTO> GetFiltered(FilterExpenseCategoryModel filter)
    {
        var query = _context.ExpenseCategories
                                            .Include(ec => ec.User)
                                            .Where(ec => ec.IsDeleted != true)
                                            .AsQueryable();
        
        if(!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(ec => ec.Name.ToLower().Contains(filter.Name.ToLower().NoAccent()));
        }

        if(!string.IsNullOrEmpty(filter.Description))
        {
            query = query.Where(ec => ec.Description.ToLower().Contains(filter.Description.ToLower().NoAccent()));
        }

        var count = await query.CountAsync();

        var result = new ListViewExpenseCategoryDTO(filter.PageIndex, filter.PageSize, count);

        query = query.OrderBy(ec => ec.Id)
                     .Paginate(filter.PageIndex, filter.PageSize);
                     
        var categoryList = await query.ToListAsync();
        result.List = categoryList.Adapt<List<ExpenseCategoryDTO>>();
        return result;
    }


    public async Task<string> Update(UpdateExpenseCategoryModel model)
    {
        var expenseCategory = await _context.ExpenseCategories.FindAsync(model.Id);
        if (expenseCategory == null || expenseCategory.IsDeleted == true)
        {
            throw new NotFoundException($"The category with the id {model.Id} does not exist.");
        }

        model.Adapt(expenseCategory);
        _context.ExpenseCategories.Update(expenseCategory);
        await _context.SaveChangesAsync();

        return $"The expense category was correctly updated.";
    }


    public async Task<bool> Delete(int id)
    {
        var expenseCategory = await _context.ExpenseCategories.FindAsync(id);
        if (expenseCategory == null || expenseCategory.IsDeleted == true)
        {
            throw new NotFoundException($"The category with the id {id} does not exist.");
        }

        expenseCategory.IsDeleted = true;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}