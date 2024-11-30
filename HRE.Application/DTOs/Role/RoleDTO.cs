using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Role;

public class RoleDTO
{
    [Required(ErrorMessage = "Tên vai trò không được để trống.")]
    [MaxLength(100, ErrorMessage = "Tên vai trò không được dài quá 100 ký tự.")]
    [MinLength(3, ErrorMessage = "Tên vai trò phải dài ít nhất 3 ký tự.")]
    public string RoleName { get; set; } = default!;

    [MaxLength(255, ErrorMessage = "Mô tả không được dài quá 255 ký tự.")]
    public string Description { get; set; } = default!;
}

