

using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Gift;

public class GiftDTO
{
    [Required(ErrorMessage = "Tên quà tặng là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên quà tặng không được dài quá 255 ký tự.")]
    public string GiftName { get; set; } = default!;

    [MaxLength(255, ErrorMessage = "URL hình ảnh không được dài quá 255 ký tự.")]
    public string ImageUrl { get; set; } = default!;
}
