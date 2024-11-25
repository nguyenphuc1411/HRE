using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Robot
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(100)")]
    public string RobotCode { get; set; } = default!;
    [Column(TypeName = "NVarchar(255)")]
    public string RobotName { get; set; } = default!;
    [Column(TypeName = "Varchar(12)")]
    public string Type { get; set; }= default!;
    public bool Status { get; set; } = false;
    public int? BatteryLevel { get; set; }
    public DateTime? LastAccess { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string? LastLocation { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public ICollection<RobotCampaign> RobotCampaigns { get; set; } = new List<RobotCampaign>();
}
