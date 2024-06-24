using System.Text.Json.Serialization;
using Core.Entities;

namespace Core.Request;

public class CreateExpenseCategoryModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}