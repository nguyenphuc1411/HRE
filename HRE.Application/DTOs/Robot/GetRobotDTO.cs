namespace HRE.Application.DTOs.Robot;
public class GetRobotDTO
{
    public int Id { get; set; }
    public string RobotCode { get; set; } = default!;
    public string RobotType { get; set; } = default!;
    public bool Status { get; set; } = false;
    public int? BatteryLevel { get; set; }
    public DateTime? LastAccess { get; set; }
    public DateTime DateAdded { get; set; } 
    public int? LocationId { get; set; }
}
