namespace HRE.Domain.Entities;

public class GiftInRule
{
    public int Id { get; set; }
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = default!;
    public int RuleId { get; set; }
    public GiftRule GiftRule { get; set; } = default!;

    public int WinningRate { get; set; }= 0;
}
