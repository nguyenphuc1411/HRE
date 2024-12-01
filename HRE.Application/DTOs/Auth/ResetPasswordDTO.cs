using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Auth;

public class ResetPasswordDTO
{
    [Required(ErrorMessage = "Email không được để trống.")]
    [MaxLength(255, ErrorMessage = "Email không được dài quá 255 ký tự.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = default!;

    public string Token { get; set; } = default!;


    [Required(ErrorMessage = "Mật khẩu không được để trống.")]
    [MinLength(5, ErrorMessage = "Mật khẩu phải dài ít nhất 5 ký tự.")]
    [MaxLength(50, ErrorMessage = "Mật khẩu không được dài quá 50 ký tự.")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ cái thường, một chữ cái in hoa và một chữ số.")]
    public string NewPassword { get; set; } = default!;
}
