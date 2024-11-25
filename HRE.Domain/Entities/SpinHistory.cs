
namespace HRE.Domain.Entities;

public class SpinHistory
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();

    public int UserId { get; set; }
    public User User { get; set; }= new();

    public int PointsAtSpin { get; set; }
    public bool SpinResult { get; set; }
    public DateTime SpinDate { get; set; }

    public int? RewardId { get; set; }
    public Reward? Reward { get; set; }
}
