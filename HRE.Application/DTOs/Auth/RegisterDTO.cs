using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Auth;

public class RegisterDTO
{
    [Required(ErrorMessage = "Họ và tên không được để trống.")]
    [MaxLength(255, ErrorMessage = "Họ và tên không được dài quá 255 ký tự.")]
    public string Fullname { get; set; } = default!;

    [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
    [MaxLength(100, ErrorMessage = "Tên đăng nhập không được dài quá 100 ký tự.")]
    [MinLength(4, ErrorMessage = "Tên đăng nhập phải dài ít nhất 4 ký tự.")]
    [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới.")]
    public string Username { get; set; } = default!;

    [Required(ErrorMessage = "Email không được để trống.")]
    [MaxLength(255, ErrorMessage = "Email không được dài quá 255 ký tự.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Mật khẩu không được để trống.")]
    [MinLength(5, ErrorMessage = "Mật khẩu phải dài ít nhất 5 ký tự.")]
    [MaxLength(50, ErrorMessage = "Mật khẩu không được dài quá 50 ký tự.")]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$", ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ cái thường, một chữ cái in hoa và một chữ số.")]
    public string Password { get; set; } = default!;
}
