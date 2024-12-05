namespace HRE.Application.DTOs.Gift;

public class GetGiftsDTO
{
    public int Id { get; set; }
    public string GiftName { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;

    public int TotalGivens { get; set; }
}
