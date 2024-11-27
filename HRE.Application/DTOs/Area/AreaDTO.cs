
using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Area;

public class AreaDTO
{
    [MaxLength(255)]
    public string Name { get; set; } = default!;

    [MaxLength(255)]
    public string Description { get; set; } = default!;
}
