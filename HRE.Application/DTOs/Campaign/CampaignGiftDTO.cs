namespace HRE.Application.DTOs.Campaign;

using System.ComponentModel.DataAnnotations;

public class CampaignGiftDTO
{
    [Required(ErrorMessage = "GiftId không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "GiftId phải lớn hơn 0.")]
    public int GiftId { get; set; }

    [Required(ErrorMessage = "CampaignId không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "CampaignId phải lớn hơn 0.")]
    public int CampaignId { get; set; }

    [Range(0, 100, ErrorMessage = "Tỉ lệ trúng thưởng phải nằm trong khoảng từ 0 đến 100.")]
    public int WinningRate { get; set; } = 0;

    [Range(0, int.MaxValue, ErrorMessage = "InitialQuantity không được nhỏ hơn 0.")]
    public int InitialQuantity { get; set; } = 0;

    [Range(0, int.MaxValue, ErrorMessage = "QuantityGiven không được nhỏ hơn 0.")]
    public int QuantityGiven { get; set; } = 0;
}
