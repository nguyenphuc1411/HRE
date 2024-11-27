
namespace HRE.Domain.Entities;

public class MachineCampaign
{
    public int MachineId { get; set; }
    public RecyclingMachine Machine { get; set; } = default!;
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = default!;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
