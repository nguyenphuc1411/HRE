namespace HRE.Application.DTOs.Campaign;

using System.ComponentModel.DataAnnotations;

public class CampaignDTO
{
    [Required(ErrorMessage = "Tên chiến dịch không được để trống.")]
    [MaxLength(255, ErrorMessage = "Tên chiến dịch không được vượt quá 255 ký tự.")]
    public string CampaignName { get; set; } = default!;

    [Required(ErrorMessage = "Ngày bắt đầu không được để trống.")]
    [DataType(DataType.DateTime, ErrorMessage = "Ngày bắt đầu không hợp lệ.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Ngày kết thúc không được để trống.")]
    [DataType(DataType.DateTime, ErrorMessage = "Ngày kết thúc không hợp lệ.")]
    public DateTime EndDate { get; set; }

    [MaxLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự.")]
    public string Description { get; set; } = default!;

    [Required(ErrorMessage = "Địa điểm không được để trống.")]
    [Range(1, int.MaxValue, ErrorMessage = "Mã địa điểm phải là số nguyên dương.")]
    public int LocationId { get; set; }
}

