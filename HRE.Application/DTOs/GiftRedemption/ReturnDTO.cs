namespace HRE.Application.DTOs.GiftRedemption;

using System.ComponentModel.DataAnnotations;

public class ReturnDTO
{
    [Required(ErrorMessage = "RedemptionId là bắt buộc.")]
    public int RedemptionId { get; set; }

    [StringLength(255, ErrorMessage = "Lý do không được vượt quá 500 ký tự.")]
    public string? Reason { get; set; }
}
