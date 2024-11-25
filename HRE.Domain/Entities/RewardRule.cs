
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RewardRule
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string RuleName { get; set; } = default!;
    public int StartRange { get; set; }
    public int EndRange { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public ICollection<GiftRewardRule> GiftRewardRules { get; set; } = new List<GiftRewardRule>();
    public ICollection<CampaignRewardRule> CampaignRewardRules { get; set; } = new List<CampaignRewardRule>();
}
