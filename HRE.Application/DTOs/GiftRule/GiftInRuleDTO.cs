
using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.GiftRule;

public class GiftInRuleDTO
{
    [Required(ErrorMessage = "Mã quà tặng không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "Mã quà tặng phải là số nguyên dương.")]
    public int GiftId { get; set; }

    [Required(ErrorMessage = "Xác suất không được để trống.")]
    [Range(0, 100, ErrorMessage = "Xác suất phải nằm trong khoảng từ 0 đến 100.")]
    public int Probability { get; set; } = 0;
}