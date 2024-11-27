
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RecyclingMachine
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(100)")]
    public string MachineCode { get; set; } = default!;
    public bool Status { get; set; } = false;
    public bool BinStatus { get; set; } = false;
    public int AccessCount { get; set; } = 0;
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public int? LocationId { get; set; }
    public Location? Location { get; set; }
    public ICollection<MachineCampaign> MachineCampaigns { get; set; } = default!;
}
