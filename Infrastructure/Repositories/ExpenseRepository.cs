using Core.Entities;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces.Repositories;
using Core.Models.ExpenseDTOs;
using Core.Request.ExpenseModels;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly PersonalExpensesContext _context;

    public ExpenseRepository(PersonalExpensesContext context)
    {
        _context = context;
    }

    public async Task<string> Add(CreateExpenseModel model)
    {
        var expense = model.Adapt<Expense>();

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        model.Id = expense.Id;

        return $"Your expense with the Id {model.Id} has been successfully charged";
    }


    public async Task<ExpenseDTO> GetById(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null || expense.IsDeleted == true)
        {
            throw new NotFoundException($"Spending with id {id} does not exist");
        }

        var expenseDTO = expense.Adapt<ExpenseDTO>();
        return expenseDTO;
    }

    public async Task<ListViewExpenseDTO> GetFiltered(FilterExpenseModel filter)
    {
        var query = _context.Expenses.Include(e => e.ExpenseCategory)
                                     .ThenInclude(e => e.User)
                                     .Where(e => e.IsDeleted != true)
                                     .AsQueryable();

        // if(!string.IsNullOrEmpty(filter.Amount.ToString()))
        // {
        //     query = query.Where(e => e.Amount.ToString().Contains(filter.Amount.ToString()));
        // }

        if (filter.Amount != null)
        {
            query = query.Where(e => e.Amount == filter.Amount);
        }

        if(!string.IsNullOrEmpty(filter.Description))
        {
            query = query.Where(e => e.Description.ToLower().Contains(filter.Description.ToLower().NoAccent()));
        }

        var count = await query.CountAsync();

        var result = new ListViewExpenseDTO(filter.PageIndex, filter.PageSize, count);

        query = query.OrderBy(e => e.Id)
                     .Paginate(filter.PageIndex, filter.PageSize);

        var expenseList = await query.ToListAsync();
        result.List = expenseList.Adapt<List<ExpenseDTO>>();
        return result;
    }

    public async Task<string> Update(UpdateExpenseModel model)
    {
        var expense = await _context.Expenses.FindAsync(model.Id);
        if (expense == null || expense.IsDeleted == true)
        {
            throw new NotFoundException($"Spending with id {model.Id} does not exist");
        }

        model.Adapt(expense);
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();

        return $"The expense was updated correctly";
    }
    public async Task<bool> Delete(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null || expense.IsDeleted == true)
        {
            throw new NotFoundException($"Spending with id {id} does not exist");
        }

        expense.IsDeleted = true;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}