namespace HRE.Application.DTOs.GiftRule;

public class GetRuleDTO
{
    public int Id { get; set; }
    public string RuleName { get; set; } = default!;
    public DateTime DateAdded { get; set; }
    public int MinPoints { get; set; }
    public int MaxPoints { get; set; }
    public string Description { get; set; } = default!;
    public int AppliedLocationCount { get; set; }  // Số địa điểm áp dụng
}
