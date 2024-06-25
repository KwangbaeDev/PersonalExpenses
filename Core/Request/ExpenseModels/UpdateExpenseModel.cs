namespace Core.Request.ExpenseModels;

public class UpdateExpenseModel
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public int ExpenseCategoryId { get; set; }
}