using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.UserInteraction;

public class FinishInteractionDTO
{
    [Required(ErrorMessage = "Id là bắt buộc.")]
    [Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "PointEarned là bắt buộc.")]
    [Range(0, int.MaxValue, ErrorMessage = "PointEarned phải là số nguyên không âm.")]
    public int PointEarned { get; set; }

    public bool IsSpin { get; set; } = false;
}
