using System.ComponentModel.DataAnnotations;
namespace HRE.Application.DTOs.RecyclingMachine;

public class UpdateRMDTO
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string MachineCode { get; set; } = default!;
    public bool Status { get; set; } 
    public bool BinStatus { get; set; }
    public int AccessCount { get; set; }
    public int? LocationId { get; set; }
}
