using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.UserPoint;

public class UserPointDTO
{
    [Required(ErrorMessage = "CampaignId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "CampaignId phải lớn hơn 0.")]
    public int CampaignId { get; set; }

    [Required(ErrorMessage = "UserId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "UserId phải lớn hơn 0.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Points là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "Points không được nhỏ hơn 0.")]
    public int Points { get; set; }
}