
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class RecyclingMachine
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(100)")]
    public string MachineCode { get; set; } = default!;
    [Column(TypeName = "Nvarchar(255)")]
    public string MachineName { get; set; } = default!;
    public bool Status { get; set; } = false;
    [Column(TypeName = "Nvarchar(20)")]
    public string Capacity { get; set; } = default!;
    public DateTime? LastAccess { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string? LastLocation { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public ICollection<MachineCampaign> MachineCampaigns { get; set; } = new List<MachineCampaign>();
}
