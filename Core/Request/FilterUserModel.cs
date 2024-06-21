namespace Core.Request;

public class FilterUserModel
{
    public string? Name { get; set; }
    public string? Email { get; set; }

    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}