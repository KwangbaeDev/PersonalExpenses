using Core.Entities;

namespace Core.Models.ExpenseDTOs;

public class ExpenseDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDatetime { get; set; }
    public string Description { get; set; } = string.Empty;
    public ExpenseCategoryDTO ExpenseCategory { get; set; } = null!;
}