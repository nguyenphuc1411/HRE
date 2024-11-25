
namespace HRE.Domain.Entities;

public class CampaignSelection
{
    public int UserId { get; set; }
    public User User { get; set; } = new();
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
}
