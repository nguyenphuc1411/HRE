using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Location;

public class LocationDTO
{
    [Required(ErrorMessage = "Tên địa điểm là bắt buộc.")]
    [MaxLength(255, ErrorMessage = "Tên địa điểm không được dài quá 255 ký tự.")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
    [MaxLength(500, ErrorMessage = "Địa chỉ không được dài quá 500 ký tự.")]
    public string Addesss { get; set; } = default!;

    [Required(ErrorMessage = "Tỉnh/Thành phố là bắt buộc.")]
    [MaxLength(100, ErrorMessage = "Tỉnh/Thành phố không được dài quá 100 ký tự.")]
    public string Province_City { get; set; } = default!;

    [Range(-180, 180, ErrorMessage = "Kinh độ phải nằm trong khoảng từ -180 đến 180.")]
    public decimal Longitude { get; set; }

    [Range(-90, 90, ErrorMessage = "Vĩ độ phải nằm trong khoảng từ -90 đến 90.")]
    public decimal Latitude { get; set; }

    [Required(ErrorMessage = "Mã khu vực là bắt buộc.")]
    public int AreaId { get; set; }
}

