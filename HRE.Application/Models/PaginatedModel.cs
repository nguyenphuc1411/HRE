namespace HRE.Application.Models;

public class PaginatedModel<T>
{
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PageCount { get; set; }
    public int Size { get; set; }

    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
}