
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class GiftRedemption
{
    public int Id { get; set; }
    public int QRCodeId { get; set; }
    public QRCode QRCode { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int PGStaffId { get; set; }
    public User PGStaff { get; set; } = default!;

    [Column(TypeName = "Nvarchar(150)")]
    public string? CustomerName { get; set; }
    [Column(TypeName = "Varchar(11)")]
    public string? CustomerPhone { get; set; }
    public DateTime RedemptionDate { get; set; } = DateTime.Now;
    [Column(TypeName = "Nvarchar(10)")]
    public string Status { get; set; } = default!;

    public GiftReturn? GiftReturn { get; set; }
}
