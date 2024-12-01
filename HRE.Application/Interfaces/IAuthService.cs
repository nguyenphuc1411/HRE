using HRE.Application.DTOs.Auth;
using HRE.Application.DTOs.User;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IAuthService
{
    Task<string> Login(LoginDTO loginDTO);

    Task<User?> Register(RegisterDTO registerDTO);

    Task<bool> RequestForgotPassword(ForgotPasswordDTO forgotPassword);

    Task<string> ConfirmRegistion(ConfirmRegistion confirmRegistion);

    Task<bool> ResetPassword(ResetPasswordDTO resetPassword);

    Task<GetUserDTO> Get();
    int GetUserID();
}
