
using System.ComponentModel.DataAnnotations;
namespace HRE.Application.DTOs.Robot;

public class UpdateRobotDTO
{
    [Required(ErrorMessage = "ID của robot là bắt buộc.")]
    public int Id { get; set; }

    [StringLength(100, ErrorMessage = "Mã robot không được dài quá 100 ký tự.")]
    public string RobotCode { get; set; } = default!;

    [StringLength(12, ErrorMessage = "Loại robot không được dài quá 12 ký tự.")]
    [RegularExpression("^(SILVERBOT|DELIVERY BOX)$", ErrorMessage = "Loại robot phải là 'SILVERBOT' hoặc 'DELIVERY BOX'.")]
    public string RobotType { get; set; } = default!;

    public bool Status { get; set; }

    [Range(0, 100, ErrorMessage = "Mức pin phải nằm trong khoảng từ 0 đến 100.")]
    public int? BatteryLevel { get; set; }

    public DateTime? LastAccess { get; set; }

    public int? LocationId { get; set; }
}

