namespace HRE.Domain.Entities;

public class GiftRewardRule
{
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = new();
    public int RewardRuleId { get; set; }
    public RewardRule RewardRule { get; set; } = new();

    public int WinningPercentage { get; set; }
}
