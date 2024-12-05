namespace HRE.Application.DTOs.RecyclingMachine;

public class GetRMDetailDTO
{
    public string MachineCode { get; set; } = default!;  // Mã máy tái chế
    public bool Status { get; set; }  // Trạng thái máy tái chế (hoạt động hay không)
    public bool BinStatus { get; set; }  // Trạng thái thùng chứa (sắp đầy hay không)
    public int AccessCount { get; set; }  // Số lượt truy cập vào máy
    public int? LocationId { get; set; }
    public string? Location { get; set; }  // Vị trí máy tái chế
    public int TotalGivens { get; set; }  // Tổng số quà đã phát
    public int TotalExpired { get; set; }  // Tổng số quà hết hạn
    public List<CampaignDTOForRM> Campaigns { get; set; } = new List<CampaignDTOForRM>();  // Danh sách chiến dịch liên quan
    public List<UserInteractionDTOForRM> Interactions { get; set; } = new List<UserInteractionDTOForRM>();  // Danh sách tương tác người dùng
}

public class CampaignDTOForRM
{
    public int CampaignId { get; set; }
    public string CampaignName { get; set; } = default!;
    public DateTime CampaignStartDate { get; set; }
    public DateTime CampaignEndDate { get; set; }
}

public class UserInteractionDTOForRM
{
    public int UserId { get; set; }
    public DateTime InteractionStartTime { get; set; }
    public DateTime? InteractionEndTime { get; set; }
    public int PointsEarned { get; set; }
    public string Result { get; set; } = default!;
    public string? GiftReceived { get; set; }
    public DateTime? RewardDate { get; set; }
    public string QRCodeStatus { get; set; } = default!;
    public DateTime? QRCodeUsedDate { get; set; }
    public int? PGStaffId { get; set; }
    public string? IssuedBy { get; set; }
}


