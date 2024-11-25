using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Reward
{
    public int Id { get; set; }
    public int GiftId { get; set; }
    public Gift Gift { get; set; } = new();
    [Column(TypeName = "varchar(max)")]
    public string QRCode { get; set; } = default!;
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddDays(1);
    public bool IsUsed { get; set; } = false;

    public SpinHistory SpinHistory { get; set; } = new();
    public RewardRedemption? RewardRedemption { get; set; }
}
