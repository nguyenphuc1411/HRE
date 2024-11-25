using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Area
{
    public int Id { get; set; }
    [Column(TypeName = "NVarchar(255)")]
    public string AreaName { get; set; } = default!;
    public ICollection<Province> Provinces { get; set; } = new List<Province>();
}
