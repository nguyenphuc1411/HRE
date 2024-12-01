using System.ComponentModel.DataAnnotations.Schema;
namespace HRE.Application.DTOs.RecyclingMachine;

public class GetRMDTO
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(100)")]
    public string MachineCode { get; set; } = default!;
    public bool Status { get; set; } = false;
    public bool BinStatus { get; set; } = false;
    public int AccessCount { get; set; } = 0;
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public int? LocationId { get; set; }
    public HRE.Domain.Entities.Location? Location { get; set; }
}
