
using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.GiftRule;

public class GiftInRuleDTO
{
    [Required(ErrorMessage = "Mã quà tặng không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "Mã quà tặng phải là số nguyên dương.")]
    public int GiftId { get; set; }

    [Required(ErrorMessage = "Tỉ lệ trúng thưởng không được để trống.")]
    [Range(0, 100, ErrorMessage = "Tỉ lệ trúng thưởng phải nằm trong khoảng từ 0 đến 100.")]
    public int WinningRate { get; set; } = 0;
}