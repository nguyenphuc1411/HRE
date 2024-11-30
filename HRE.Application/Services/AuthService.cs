using HRE.Application.DTOs.Auth;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace HRE.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IConfiguration config;
    private readonly IHttpContextAccessor httpContextAccessor;
    public AuthService(IUserRepository userRepository, IConfiguration config, IHttpContextAccessor httpContextAccessor)
    {
        this.userRepository = userRepository;
        this.config = config;
        this.httpContextAccessor = httpContextAccessor;
    }

    public int GetUserID()
    {
        return int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("Không tìm thấy UserID"));
    }

    public async Task<string> Login(LoginDTO loginDTO)
    {
        var user = await userRepository.GetByCondition(x => x.Email == loginDTO.Email && x.Status);

        if (user == null)
        {
            return string.Empty;
        }

        // Sử dụng PasswordHasher để kiểm tra mật khẩu đã được hash
        var passwordHasher = new PasswordHasher<User>(); // Khởi tạo PasswordHasher
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.Password, loginDTO.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            return string.Empty; 
        }

        return AuthExtentions.GenerateToken(user.Id.ToString(), config["JWT:Key"] ?? throw new Exception("No JWT KEY"));
    }

    public async Task<User?> Register(RegisterDTO registerDTO)
    {
        // Kiem tra username va email
        var check = await userRepository.GetByCondition(x => x.Email == registerDTO.Email || x.Username == registerDTO.Username);
        if (check != null) return null;

        var newUser = new User
        {
            Fullname = registerDTO.Fullname,
            Email = registerDTO.Email,
            Username = registerDTO.Username,
            Status = false,
            RoleId = 3 // ROLE 3 dành cho Customer
        };
        newUser.Password = new PasswordHasher<User>().HashPassword(newUser, registerDTO.Password);

        return await userRepository.Create(newUser);
    }
}
