using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Role;

public class RoleDTO
{
    [MaxLength(100)]
    public string RoleName { get; set; } = default!;
    [MaxLength(255)]
    public string Description { get; set; } = default!;
}
