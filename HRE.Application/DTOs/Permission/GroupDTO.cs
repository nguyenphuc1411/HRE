

using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Permission;

public class GroupDTO
{
    [Required(ErrorMessage = "Tên nhóm là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên nhóm không được dài quá 255 ký tự.")]
    [MinLength(3, ErrorMessage = "Tên nhóm phải có ít nhất 3 ký tự.")]
    public string GroupName { get; set; } = default!;
}
