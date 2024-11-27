using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Permission
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string PermissionName { get; set; } = default!;

    public int GroupId { get; set; }
    public PermissionGroup PermissionGroup { get; set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; set; } = default!;
}
