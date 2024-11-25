using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Campaign
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string CampaignName { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description {  get; set; }= default!;
    public int LocationId { get; set; }
    public Location Location { get; set; } = new();

    public ICollection<RobotCampaign> RobotCampaigns { get; set; } = new List<RobotCampaign>();
    public ICollection<MachineCampaign> MachineCampaigns { get; set; } = new List<MachineCampaign>();
    public ICollection<UserPoint> UserPoints { get; set; }= new List<UserPoint>();
    public ICollection<SpinHistory> SpinHistories { get; set; }= new List<SpinHistory>();
    public ICollection<CampaignGiftRule> CampaignGiftRules { get; set; }= new List<CampaignGiftRule>();
}
