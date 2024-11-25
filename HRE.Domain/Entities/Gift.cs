using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Gift
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string GiftName { get; set; } = default!;
    [Column(TypeName = "varchar(255)")]
    public string ImageUrl { get; set; } = default!;

    public ICollection<CampaignGift> CampaignGifts { get; set; } = new List<CampaignGift>();
    public ICollection<Reward> Rewards { get; set; } = new List<Reward>();
    public ICollection<GiftRewardRule> GiftRewardRules { get; set; }= new List<GiftRewardRule>();
}
