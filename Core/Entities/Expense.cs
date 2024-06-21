namespace Core.Entities;

public class Expense : BaseEntity
{
    public decimal Amount { get; set; }
    public DateTime ExpenseDatetime { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public int ExpenseCategoryId { get; set; }
    public ExpenseCategory ExpenseCategory { get; set; } = null!;
}