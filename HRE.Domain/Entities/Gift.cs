using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Gift
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string GiftName { get; set; } = default!;
    [Column(TypeName = "varchar(255)")]
    public string ImageUrl { get; set; } = default!;

    public ICollection<GiftInRule> GiftInRules { get; set; } = default!;
    public ICollection<UserInteraction> UserInteractions { get; set; } = default!;
    public ICollection<CampaignGift> CampaignGifts { get; set; } = default!;
}
