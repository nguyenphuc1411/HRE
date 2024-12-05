
namespace HRE.Application.DTOs.Gift;

public class GetGiftDTO
{
    public int Id { get; set; }
    public string GiftName { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;

    // Tổng số lượng quà đã phát từ PG
    public int TotalGivens { get; set; }

    // Tổng số lượng quà hết hạn (khách hàng không nhận trong 24 giờ)
    public int TotalExpired { get; set; }
}
