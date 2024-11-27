

using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Gift;

public class GiftDTO
{
    [MaxLength(255)]
    public string GiftName { get; set; } = default!;
    [MaxLength(255)]
    public string ImageUrl { get; set; } = default!;
}
