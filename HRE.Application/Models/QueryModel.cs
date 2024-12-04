namespace HRE.Application.Models;

public class QueryModel
{
    public string? SearchTerm { get; set; }  
    public string? SortBy { get; set; }    
    public bool Ascending { get; set; } = true;    

    // Các tham số phân trang
    public int Page { get; set; } = 1; 
    public int PageSize { get; set; } = 10;     
}
