using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Location;

public class LocationDTO
{
    [MaxLength(255)]
    public string Name { get; set; } = default!;
    public string Addesss { get; set; } = default!;

    [MaxLength(100)]
    public string Province_City { get; set; } = default!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public int AreaId { get; set; }
}
