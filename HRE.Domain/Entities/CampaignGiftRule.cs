namespace HRE.Domain.Entities;

public class CampaignGiftRule
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
    public int GiftInRuleId { get; set; }
    public GiftInRule GiftInRule { get; set; } = new ();

    public int InitialQuantity { get; set; } = 0;
    public int QuantityGiven { get; set; } = 0;
}
