namespace HRE.Domain.Entities;

public class CampaignGift
{
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = new();

    public int Quantity { get; set; }
}

