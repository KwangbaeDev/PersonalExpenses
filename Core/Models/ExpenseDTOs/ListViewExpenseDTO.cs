using Core.Entities;

namespace Core.Models.ExpenseDTOs;

public class ListViewExpenseDTO
{
    public List<ExpenseDTO> List { get; set;} = new List<ExpenseDTO>();
    public int Page { get; set; }
    public int SizeRegisters { get; set; }
    public int TotalPages { get; set; }
    public int TotalRegisters { get; set; }

    public ListViewExpenseDTO(int pageIndex, int pageSize, IQueryable<Expense> list)
    {
        Page = pageIndex;
        SizeRegisters = pageSize;
        TotalPages = (int)Math.Ceiling(list.Count() / (double)pageSize);
        TotalRegisters = list.Count();
    }
}