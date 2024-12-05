namespace HRE.Domain.Entities;

public class CampaignGift
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = default!;
    public int InitialQuantity { get; set; } = 0;
    public int QuantityGiven { get; set; } = 0;
    public int WonQuantity { get; set; } = 0;
}
