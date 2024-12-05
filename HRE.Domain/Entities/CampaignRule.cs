namespace HRE.Domain.Entities;

public class CampaignRule
{
    public int RuleId { get; set; }
    public GiftRule GiftRule { get; set; } = default!;

    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;
}
