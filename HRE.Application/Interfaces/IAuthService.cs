using HRE.Application.DTOs.Auth;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IAuthService
{
    Task<string> Login(LoginDTO loginDTO);

    Task<User?> Register(RegisterDTO registerDTO);

    int GetUserID();
}
