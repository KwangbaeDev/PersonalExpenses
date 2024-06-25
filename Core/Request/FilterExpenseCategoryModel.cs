namespace Core.Request;

public class FilterExpenseCategoryModel
{
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}