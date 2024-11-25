using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Robot;

public class CreateRobotDTO
{
    [StringLength(100)]
    public string RobotCode { get; set; } = default!;

    [StringLength(12)]
    [RegularExpression("^(SILVERBOT|DELIVERY BOX)$", ErrorMessage = "Type must be either 'SILVERBOT' or 'DELIVERY BOX'.")]
    public string RobotType { get; set; } = default!;
}
