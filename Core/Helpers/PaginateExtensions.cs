namespace Core.Helpers;

public static class PaginateExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageIndex, int pageSize)
    {
        return query.Skip((pageIndex -1) * pageSize)
                    .Take(pageSize);
    }
}