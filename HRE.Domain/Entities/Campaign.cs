using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Campaign
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string CampaignName { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = default!;
    public int LocationId { get; set; }
    public Location Location { get; set; } = default!;

    public ICollection<RobotCampaign> RobotCampaigns { get; set; } = default!;
    public ICollection<MachineCampaign> MachineCampaigns { get; set; } = default!;
    public ICollection<UserPoint> UserPoints { get; set; } = default!;
    public ICollection<SpinHistory> SpinHistories { get; set; } = default!;
    public ICollection<CampaignGiftRule> CampaignGiftRules { get; set; } = default!;
}
