
using System.ComponentModel.DataAnnotations;
namespace HRE.Application.DTOs.Robot;

public class UpdateRobotDTO
{
    public int Id { get; set; }
    [StringLength(100)]
    public string RobotCode { get; set; } = default!;

    [StringLength(12)]
    [RegularExpression("^(SILVERBOT|DELIVERY BOX)$", ErrorMessage = "Type must be either 'SILVERBOT' or 'DELIVERY BOX'.")]
    public string RobotType { get; set; } = default!;
    public bool Status { get; set; }
    [Range(0,100,ErrorMessage ="Battery Level must be betwwen 0 and 100.")]
    public int? BatteryLevel { get; set; }
    public DateTime? LastAccess { get; set; }
    public int? LocationId { get; set; }
}
