using System.ComponentModel.DataAnnotations;
namespace HRE.Application.DTOs.RecyclingMachine;

public class UpdateRMDTO
{
    [Required(ErrorMessage = "ID là bắt buộc.")]
    public int Id { get; set; }

    [MaxLength(100, ErrorMessage = "Mã máy không được dài quá 100 ký tự.")]
    public string MachineCode { get; set; } = default!;

    public bool Status { get; set; }

    public bool BinStatus { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Số lần truy cập phải là số nguyên dương.")]
    public int AccessCount { get; set; }

    public int? LocationId { get; set; }
}
