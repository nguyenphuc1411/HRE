
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RewardRedemption
{
    public int Id { get; set; }
    public int RewardId { get; set; }
    public Reward Reward { get; set; } = new();
    public int RedeemedBy { get; set; }
    public User User { get; set; }= new();
    [Column(TypeName = "Nvarchar(150)")]
    public string? CustomerName { get; set; }
    [Column(TypeName = "Varchar(11)")]
    public string? CustomerPhone { get; set; }
    public DateTime RedemptionDate { get; set; }
    [Column(TypeName = "Nvarchar(10)")]
    public string Status { get; set; } = default!;

    public ICollection<RedemptionHistory> RedemptionHistories { get; set; } = new List<RedemptionHistory>();
}
