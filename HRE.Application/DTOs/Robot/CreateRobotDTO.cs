using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Robot;

public class CreateRobotDTO
{
    [Required(ErrorMessage = "Mã robot là bắt buộc.")]
    [StringLength(100, ErrorMessage = "Mã robot không được dài quá 100 ký tự.")]
    public string RobotCode { get; set; } = default!;

    [Required(ErrorMessage = "Loại robot là bắt buộc.")]
    [StringLength(12, ErrorMessage = "Loại robot không được dài quá 12 ký tự.")]
    [RegularExpression("^(SILVERBOT|DELIVERY BOX)$", ErrorMessage = "Loại robot phải là 'SILVERBOT' hoặc 'DELIVERY BOX'.")]
    public string RobotType { get; set; } = default!;
}
