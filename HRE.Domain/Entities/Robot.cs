using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class Robot
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(100)")]
    public string RobotCode { get; set; } = default!;
    [Column(TypeName = "Varchar(20)")]
    public string RobotType { get; set; }= default!;
    public bool Status { get; set; } = false;
    public int? BatteryLevel { get; set; }
    public DateTime? LastAccess { get; set; }
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public int? LocationId { get; set; }
    public Location? Location { get; set; }
    public ICollection<RobotCampaign> RobotCampaigns { get; set; } = new List<RobotCampaign>();
}
