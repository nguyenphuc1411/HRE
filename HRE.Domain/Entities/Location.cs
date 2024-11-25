
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Location
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string Name { get; set; } = default!;
    public string Addesss { get; set; } = default!;

    [Column(TypeName = "Nvarchar(100)")]
    public string Province_City { get; set; } = default!;
    public decimal Longitude { get; set; }
    [Column(TypeName = "Decimal(9,6)")]
    public decimal Latitude { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public int AreaId { get; set; }
    public Area Area { get; set; } = new();
    public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}
