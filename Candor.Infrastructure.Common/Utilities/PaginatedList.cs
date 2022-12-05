namespace Candor.Infrastructure.Common.Utilities;

/// <summary>
/// Paginated list.
/// </summary>
/// <typeparam name="T">List.</typeparam>
public class PaginatedList<T> : List<T>
{
    /// <summary>
    /// Current page index.
    /// </summary>
    public int PageIndex { get; }

    /// <summary>
    /// Total pages.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="items">Items to fill paginated list.</param>
    /// <param name="count">Items count.</param>
    /// <param name="pageIndex">Selected page index.</param>
    /// <param name="pageSize">Describes amount of elements on one page.</param>
    public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        this.AddRange(items);
    }

    /// <summary>
    /// Describes availability of previous page.
    /// </summary>
    public bool HasPreviousPage => PageIndex > 1;

    /// <summary>
    /// Describes availability of next page.
    /// </summary>
    public bool HasNextPage => PageIndex < TotalPages;

    /// <summary>
    /// Creates paginated list.
    /// </summary>
    /// <param name="source">Source data.</param>
    /// <param name="pageIndex">Selected page index.</param>
    /// <param name="pageSize">Describes amount of elements on one page.</param>
    /// <returns></returns>
    public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}
