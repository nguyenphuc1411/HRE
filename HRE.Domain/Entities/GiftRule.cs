
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class GiftRule
{
    public int Id { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string RuleName { get; set; } = default!;
    public int MinPoints { get; set; }
    public int MaxPoints { get; set; }
    [Column(TypeName = "Nvarchar(255)")]
    public string Description { get; set; } = default!;
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public ICollection<GiftInRule> GiftInRules { get; set; } = new List<GiftInRule>();
}
