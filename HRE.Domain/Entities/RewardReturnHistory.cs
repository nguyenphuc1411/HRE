using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RewardReturnHistory
{
    public int Id { get; set; }
    public int RedemptionId { get; set; }
    public RewardRedemption RewardRedemption { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public DateTime ActionDate { get; set; } = DateTime.Now;
    [Column(TypeName = "Nvarchar(255)")]
    public string? Reason { get; set; }
}
