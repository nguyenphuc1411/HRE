
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Location
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string LocationName { get; set; } = default!;
    [Column(TypeName = "Nvarchar(100)")]
    public string District { get; set; } = default!;
    [Column(TypeName = "Nvarchar(100)")]
    public string Ward { get; set; } = default!;
    [Column(TypeName = "Decimal(9,6)")]
    public decimal Longitude { get; set; }
    [Column(TypeName = "Decimal(9,6)")]
    public decimal Latitude { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = new();

    public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();
}
