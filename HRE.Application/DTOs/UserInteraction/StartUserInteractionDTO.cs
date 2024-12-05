using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.UserInteraction;

public class StartUserInteractionDTO
{
    [Required(ErrorMessage = "MachineId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "MachineId phải lớn hơn 0.")]
    public int MachineId { get; set; }

    [Required(ErrorMessage = "CampaignId là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "CampaignId phải lớn hơn 0.")]
    public int CampaignId { get; set; }
}
