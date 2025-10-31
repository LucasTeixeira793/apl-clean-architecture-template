namespace CleanArchitecture.Domain.Abstractions.Extensions;

public static class LinqToDbExtensions
{
    public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageIndex, int pageSize)
    {
        if (pageIndex < 0) pageIndex = 0;
        if (pageSize <= 0) pageSize = 1;
        return source.Skip(pageIndex * pageSize).Take(pageSize);
    }
}
