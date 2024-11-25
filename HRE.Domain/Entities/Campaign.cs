using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Campaign
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string CampaignName { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; } = new();

    public ICollection<RobotCampaign> RobotCampaigns { get; set; } = new List<RobotCampaign>();
    public ICollection<MachineCampaign> MachineCampaigns { get; set; } = new List<MachineCampaign>();
    public ICollection<CampaignSelection> CampaignSelections { get; set; } = new List<CampaignSelection>();
    public ICollection<AccumulationPoint> AccumulationPoints { get; set; }= new List<AccumulationPoint>();
    public ICollection<SpinHistory> SpinHistories { get; set; }= new List<SpinHistory>();
    public ICollection<CampaignRewardRule> CampaignRewardRules { get; set; }= new List<CampaignRewardRule>();
    public ICollection<CampaignGift> CampaignGifts { get; set; } = new List<CampaignGift>();
}
