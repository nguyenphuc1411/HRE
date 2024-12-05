using HRE.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Application.DTOs.GiftRedemption;

public class RedemptionDTO
{
    [Required(ErrorMessage = "QRCodeId là bắt buộc.")]
    public int QRCodeId { get; set; }

    [Required(ErrorMessage = "UserId là bắt buộc.")]
    public int UserId { get; set; }

    [StringLength(150, ErrorMessage = "Tên khách hàng không được vượt quá 150 ký tự.")]
    public string? CustomerName { get; set; }

    [StringLength(11, ErrorMessage = "Số điện thoại phải có 11 ký tự.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải chỉ chứa các chữ số và có 10 hoặc 11 ký tự.")]
    public string? CustomerPhone { get; set; }
}