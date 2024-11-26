using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.RecyclingMachine;

public class CreateRMDTO
{
    [MaxLength(100)]
    public string MachineCode { get; set; } = default!;
}
