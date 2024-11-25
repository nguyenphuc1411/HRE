
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Province
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string ProvinceName { get; set; } = default!;

    public int AreaId { get; set; }
    public Area Area { get; set; } = new();

    public ICollection<Location> Locations { get; set; } = new List<Location>();
}
