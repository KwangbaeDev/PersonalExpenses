namespace Core.Request.ExpenseModels;

public class FilterExpenseModel
{
    public decimal? Amount { get; set; }
    public string? Description { get; set; } = string.Empty;

    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}