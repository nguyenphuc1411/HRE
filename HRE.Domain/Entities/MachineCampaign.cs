
namespace HRE.Domain.Entities;

public class MachineCampaign
{
    public int MachineId { get; set; }
    public RecyclingMachine Machine { get; set; } = new();
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = new();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
