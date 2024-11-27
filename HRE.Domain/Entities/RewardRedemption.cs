
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RewardRedemption
{
    public int Id { get; set; }
    public int RewardId { get; set; }
    public Reward Reward { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    [Column(TypeName = "Nvarchar(150)")]
    public string? CustomerName { get; set; }
    [Column(TypeName = "Varchar(11)")]
    public string? CustomerPhone { get; set; }
    public DateTime RedemptionDate { get; set; } = DateTime.Now;
    [Column(TypeName = "Nvarchar(10)")]
    public string Status { get; set; } = default!;

    public RewardReturnHistory? RewardReturnHistory { get; set; }
}
