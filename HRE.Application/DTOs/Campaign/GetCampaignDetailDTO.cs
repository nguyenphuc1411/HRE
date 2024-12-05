namespace HRE.Application.DTOs.Campaign;

public class GetCampaignDetailDTO
{
    public int Id { get; set; } // ID của chiến dịch
    public string CampaignName { get; set; } = default!; // Tên chiến dịch
    public DateTime StartDate { get; set; } // Ngày bắt đầu chiến dịch
    public DateTime EndDate { get; set; } // Ngày kết thúc chiến dịch
    public string Description { get; set; } = default!; // Mô tả chiến dịch
    public int LocationId { get; set; } // ID của địa điểm tổ chức chiến dịch

    // Tổng số quà tặng
    public int TotalGifts { get; set; }

    // Tổng số quà đã trúng (số quà khách hàng đã quay thưởng và trúng)
    public int TotalGiftsWon { get; set; }

    // Tổng số quà đã phát (quà đã xác nhận phát từ PG)
    public int TotalGiftsDistributed { get; set; }

    // Tổng số quà chưa phát (quà đã trúng nhưng chưa được phát và chưa hết hạn)
    public int TotalGiftsNotDistributed { get; set; }

    // Tổng số quà tặng hết hạn (quà đã trúng nhưng khách hàng không nhận và đã hết hạn)
    public int TotalExpiredGifts { get; set; }

    // Tổng số quà tặng hiện tại tại kho (tính bằng công thức: Tổng số quà tặng - Tổng số quà đã phát)
    public int TotalGiftsInStock { get; set; }

}

