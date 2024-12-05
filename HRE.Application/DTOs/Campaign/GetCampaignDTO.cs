namespace HRE.Application.DTOs.Campaign;

public class GetCampaignDTO
{
    public int Id { get; set; }
    public string CampaignName { get; set; } = default!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Description { get; set; } = default!;
    public int LocationId { get; set; }

    public int TotalInteraction { get; set; }
    public int TotalQRCode { get; set; }
}
