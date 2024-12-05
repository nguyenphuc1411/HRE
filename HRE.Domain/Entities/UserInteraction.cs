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

    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime? EndTime { get; set; }

    public int? PointEarned { get; set; }

    public bool IsSpun { get; set; }= false;

    public bool? IsWon { get; set; }

    public DateTime? SpunDate { get; set; } 

    public QRCode? QRCode { get; set; }
}
