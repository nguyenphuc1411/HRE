using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RedemptionHistory
{
    public int Id { get; set; }
    public int RedemptionID { get; set; }
    public RewardRedemption RewardRedemption { get; set; } = new();
    public int PerformBy { get; set; }
    public User User { get; set; }= new();
    [Column(TypeName = "Nvarchar(10)")]
    public string Action { get; set; } = default!;
    public DateTime ActionDate { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string? Reason { get; set; }
}
