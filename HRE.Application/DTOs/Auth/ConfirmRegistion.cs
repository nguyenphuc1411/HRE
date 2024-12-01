using System.ComponentModel.DataAnnotations;

namespace HRE.Application.DTOs.Auth;

public class ConfirmRegistion
{
    [Required(ErrorMessage = "Email không được để trống.")]
    [MaxLength(255, ErrorMessage = "Email không được dài quá 255 ký tự.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = default!;

    public string Token { get; set; } = default!;
}
