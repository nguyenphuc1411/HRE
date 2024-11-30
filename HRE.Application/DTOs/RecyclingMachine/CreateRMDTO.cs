using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.RecyclingMachine;

public class CreateRMDTO
{
    [Required(ErrorMessage = "Mã máy là bắt buộc.")]
    [MaxLength(100, ErrorMessage = "Mã máy không được dài quá 100 ký tự.")]
    public string MachineCode { get; set; } = default!;
}
