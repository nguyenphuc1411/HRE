using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class PermissionGroup
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string GroupName { get; set; } = default!;
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
