namespace HRE.Domain.Entities;

public class QRCode
{
    public int Id { get; set; }

    public int InteractionId { get; set; }
    public UserInteraction UserInteraction { get; set; } = default!;

    public string QRCodeURL { get; set; } = default!;

    public bool IsUsed { get; set; } = false;

    public DateTime IssuedDate { get; set; } = DateTime.Now;

    public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(1);

    public DateTime? UsedDate { get; set; }

    public GiftRedemption? GiftRedemption { get; set; }
}
