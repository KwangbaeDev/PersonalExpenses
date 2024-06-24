using Core.Entities;

namespace Core.Models;

public class ListViewExpenseCategoryDTO
{
    public List<ExpenseCategoryDTO> List { get; set;} = new List<ExpenseCategoryDTO>();
    public int Page { get; set; }
    public int SizeRegisters { get; set; }
    public int TotalPages { get; set; }
    public int TotalRegisters { get; set; }

    public ListViewExpenseCategoryDTO(int pageIndex, int pageSize, IQueryable<ExpenseCategory> list)
    {
        Page = pageIndex;
        SizeRegisters = pageSize;
        TotalPages = (int)Math.Ceiling(list.Count() / (double)pageSize);
        TotalRegisters = list.Count();
    }
    
}