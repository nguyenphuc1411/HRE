
namespace HRE.Domain.Entities;

public class AccumulationPoint
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();

    public int UserId { get; set; }
    public User User { get; set; } = new();

    public int TotalPoints { get; set; }

    public DateTime LastUpdated { get; set; }
}
