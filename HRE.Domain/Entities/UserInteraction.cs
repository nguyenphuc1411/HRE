namespace HRE.Domain.Entities;

public class UserInteraction
{
    public int Id { get; set; }

    public int MachineId { get; set; }
    public RecyclingMachine RecyclingMachine { get; set; } = default!;

    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int? GiftId { get; set; }
    public Gift? Gift { get; set; }

    public DateTime StartTime { get; set; }

    public int PointEarned { get; set; }

    public bool IsSpun { get; set; }

    public bool IsWon { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public QRCode? QRCode { get; set; }
}
