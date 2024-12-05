using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class GiftReturn
{
    public int Id { get; set; }
    public int RedemptionId { get; set; }
    public GiftRedemption GiftRedemption { get; set; } = default!;
    public int PGStaffId { get; set; }
    public User PGStaff { get; set; } = default!;
    public DateTime ActionDate { get; set; } = DateTime.Now;
    [Column(TypeName = "Nvarchar(255)")]
    public string? Reason { get; set; }
}
