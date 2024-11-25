using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RewardReturnHistory
{
    public int Id { get; set; }
    public int RedemptionId { get; set; }
    public RewardRedemption RewardRedemption { get; set; } = new();
    public int UserId { get; set; }
    public User User { get; set; }= new();

    public DateTime ActionDate { get; set; } = DateTime.Now;
    [Column(TypeName = "Nvarchar(255)")]
    public string? Reason { get; set; }
}
