

using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Permission;

public class PermissionDTO
{
    [Required(ErrorMessage = "Tên quyền là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên quyền không được dài quá 255 ký tự.")]
    [MinLength(3, ErrorMessage = "Tên quyền phải có ít nhất 3 ký tự.")]
    public string PermissionName { get; set; } = default!;

    [Required(ErrorMessage = "Mã nhóm quyền là bắt buộc.")]
    public int GroupId { get; set; }
}

