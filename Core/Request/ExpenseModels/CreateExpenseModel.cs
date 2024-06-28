using System.Text.Json.Serialization;

namespace Core.Request.ExpenseModels;

public class CreateExpenseModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public int ExpenseCategoryId { get; set; }
    public int UserId { get; set; }
}
