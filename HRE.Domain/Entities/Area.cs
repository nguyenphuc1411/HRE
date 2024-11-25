using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Area
{
    public int Id { get; set; }
    [Column(TypeName = "NVarchar(255)")]
    public string Name { get; set; } = default!;

    [Column(TypeName = "NVarchar(255)")]
    public string Description { get; set; } = default!;
    public ICollection<Location> Locations { get; set; } = new List<Location>();
}
