namespace HRE.Application.DTOs.Campaign;

using System.ComponentModel.DataAnnotations;

public class CampaignGiftRuleDTO
{
    [Required(ErrorMessage = "GiftInRuleId không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "GiftInRuleId phải lớn hơn 0.")]
    public int GiftInRuleId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "InitialQuantity không được nhỏ hơn 0.")]
    public int InitialQuantity { get; set; } = 0;

    [Range(0, int.MaxValue, ErrorMessage = "QuantityGiven không được nhỏ hơn 0.")]
    public int QuantityGiven { get; set; } = 0;
}
