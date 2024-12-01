
using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.GiftRule;

public class GiftRuleDTO
{
    [Required(ErrorMessage = "Tên quy tắc là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên quy tắc không được dài quá 255 ký tự.")]
    public string RuleName { get; set; } = default!;

    [Range(0, int.MaxValue, ErrorMessage = "Điểm tối thiểu phải là một số không âm.")]
    public int MinPoints { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Điểm tối đa phải là một số không âm.")]
    public int MaxPoints { get; set; }

    [MaxLength(255, ErrorMessage = "Mô tả không được dài quá 255 ký tự.")]
    public string Description { get; set; } = default!;
}
