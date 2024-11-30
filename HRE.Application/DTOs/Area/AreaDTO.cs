
using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Area;

public class AreaDTO
{
    [Required(ErrorMessage = "Tên khu vực là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên khu vực không được dài quá 255 ký tự.")]
    public string Name { get; set; } = default!;

    [MaxLength(255, ErrorMessage = "Mô tả không được dài quá 255 ký tự.")]
    public string Description { get; set; } = default!;
}
