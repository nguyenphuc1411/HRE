
namespace HRE.Domain.Entities;

public class RobotCampaign
{
    public int RobotId { get; set; }
    public Robot Robot { get; set; } = default!;
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
