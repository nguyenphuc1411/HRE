
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(100)")]
    public string RoleName { get; set; } = default!;
    [Column(TypeName = "Nvarchar(255)")]
    public string Description { get; set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; set; }= new List<RolePermission>();
    public ICollection<User> Users { get; set; }= new List<User>();
}
