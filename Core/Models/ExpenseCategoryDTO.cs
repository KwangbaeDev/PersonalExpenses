using Core.Entities;

namespace Core.Models;

public class ExpenseCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public UserDTO User { get; set; } = null!;
}