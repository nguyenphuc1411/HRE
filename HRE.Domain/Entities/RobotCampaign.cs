
namespace HRE.Domain.Entities;

public class RobotCampaign
{
    public int RobotId { get; set; }
    public Robot Robot { get; set; } = new();
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
