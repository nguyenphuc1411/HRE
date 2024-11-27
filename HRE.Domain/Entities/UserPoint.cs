
namespace HRE.Domain.Entities;

public class UserPoint
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int Points { get; set; }

    public DateTime LastUpdated { get; set; }
}
