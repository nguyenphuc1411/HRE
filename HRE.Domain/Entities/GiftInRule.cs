namespace HRE.Domain.Entities;

public class GiftInRule
{
    public int Id { get; set; }
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = new();
    public int RuleId { get; set; }
    public GiftRule GiftRule { get; set; } = new();

    public int Probability { get; set; }= 0;

    public ICollection<CampaignGiftRule> CampaignGiftRules { get; set; } = new List<CampaignGiftRule>();
}
