namespace HRE.Domain.Entities;

public class CampaignRewardRule
{
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
    public int RewardRuleId { get; set; }
    public RewardRule RewardRule { get; set; } = new();
}
