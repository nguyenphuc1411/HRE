using HRE.Application.DTOs.Auth;
using HRE.Application.DTOs.Mail;
using HRE.Application.DTOs.User;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System.Security.Claims;

namespace HRE.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly IConfiguration config;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly SendMailService sendMailService;
    private readonly IUserTokenRepository userTokenRepository;
    public AuthService(IUserRepository userRepository, 
        IConfiguration config, 
        IHttpContextAccessor httpContextAccessor, 
        SendMailService sendMailService, 
        IUserTokenRepository userTokenRepository)
    {
        this.userRepository = userRepository;
        this.config = config;
        this.httpContextAccessor = httpContextAccessor;
        this.sendMailService = sendMailService;
        this.userTokenRepository = userTokenRepository;
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

        var user = await userRepository.Create(newUser);

        if(user!= null)
        {
            // Gửi mail xác nhận đăng ký

            var tokenNew = Guid.NewGuid().ToString();

            var newUserToken = new UserToken
            {
                Email = newUser.Email,
                Token = tokenNew,
                TokenType = "CONFIRM REGISTION",
                UserId = newUser.Id
            };
            await userTokenRepository.Create(newUserToken);

            var origin = config["OriginFE"] ?? "linkfrontend";

            string link = origin + "/confirm-registion?email=" + newUser.Email + "&token=" + tokenNew;


            var newMail = new MailRequest
            {
                ToEmail = registerDTO.Email,
                Subject = "Register account successfully",
                Body = AuthExtentions.GenerateRegistrationSuccessEmail(newUser.Fullname, link)
            };
            await sendMailService.SendEmailAsync(newMail);
        }
        return user;
    }

    public async Task<bool> RequestForgotPassword(ForgotPasswordDTO forgotPassword)
    {
        var user = await userRepository.GetByCondition(x=>x.Email== forgotPassword.Email);
        if (user == null) return false;

        // Tạo token mới
        var newToken = Guid.NewGuid().ToString();
        // Tạo resetLink
        string resetPasswordLink = $"{config["OriginFE"]}/account/resetpassword?email={user.Email}&token={newToken}";
        // Check token hệ thống
        var tokenUsers = await userTokenRepository.GetsByCondition(x => x.UserId == user.Id && x.TokenType == "FORGOT PASSWORD");
        if (tokenUsers.Count()==0)
        {
            // Chưa có trong hệ thống và xác nhận gửi mail
            var mailRequest = new MailRequest
            {
                ToEmail = forgotPassword.Email,
                Subject = "Reset Password Confirm",
                Body = AuthExtentions.GenerateForgotPasswordEmailBody(user.Fullname, resetPasswordLink)
            };

            var isSendMailSuccess = await sendMailService.SendEmailAsync(mailRequest);
            if (isSendMailSuccess)
            {
                // Lưu thông tin token vào database
                var userToken = new UserToken
                {
                    Token = newToken,
                    TokenType = "FORGOT PASSWORD",
                    Email = user.Email,
                    UserId = user.Id
                };
                var result = await userTokenRepository.Create(userToken);

                return result != null;
            }
            else
            {
               return false;
            }
        }
        // Đã có token 

        var newestToken = tokenUsers.OrderByDescending(x => x.ExpirationDate).FirstOrDefault();
        if (newestToken?.ExpirationDate > DateTime.Now)
        {
            var remainTime = (int)Math.Ceiling((newestToken.ExpirationDate - DateTime.Now).TotalMinutes);
            // Chưa hết hạn token cũ
            return false;
        }

        var mailRequest1 = new MailRequest
        {
            ToEmail = forgotPassword.Email,
            Subject = "Reset Password Confirm",
            Body = AuthExtentions.GenerateForgotPasswordEmailBody(user.Fullname, resetPasswordLink)
        };

        var isSendMailSuccess1 = await sendMailService.SendEmailAsync(mailRequest1);

        if (isSendMailSuccess1)
        {
            // Lưu thông tin token vào database
            var userToken1 = new UserToken
            {
                Token = newToken,
                TokenType = "FORGOT PASSWORD",
                Email = user.Email,
                UserId = user.Id
            };
            var result = await userTokenRepository.Create(userToken1);

            return result != null;
        }
        return false;
    }

    public async Task<string> ConfirmRegistion(ConfirmRegistion confirmRegistion)
    {
        var check = await userTokenRepository.GetByCondition(x=>x.Email==confirmRegistion.Email &&
        x.Token==confirmRegistion.Token&&x.TokenType== "CONFIRM REGISTION" && !x.IsUsed);

        if (check == null) return string.Empty;

        var user = await userRepository.GetByCondition(x => x.Email == confirmRegistion.Email);
        if(user == null) return string.Empty;
        user.Status = true;

        var result = await userRepository.Update(user);

        if (result)
        {
            check.IsUsed = true;
            await userTokenRepository.Update(check);
            var token = AuthExtentions.GenerateToken(user.Id.ToString(), config["JWT:Key"] ?? throw new Exception("Not found key for JWT"));
            return token;
        }
        return string.Empty;
    }

    public async Task<bool> ResetPassword(ResetPasswordDTO resetPassword)
    {
        var userToken = await userTokenRepository.GetByCondition(x => x.TokenType == "FORGOT PASSWORD" && x.ExpirationDate > DateTime.Now &&
        x.Token == resetPassword.Token && x.Email == resetPassword.Email && !x.IsUsed);
        if (userToken == null) return false;

        var user = await userRepository.GetByCondition(x => x.Email == resetPassword.Email);
        if(user == null) return false;

        user.Password = new PasswordHasher<User>().HashPassword(user,resetPassword.NewPassword);

        return await userRepository.Update(user);
    }

    public async Task<GetUserDTO> Get()
    {
        int userID = GetUserID();

        var data = await userRepository.GetByIDQuery(userID);
        if (data == null) throw new Exception("Not found user by ID");
        var result = new GetUserDTO
        {
            Id = data.Id,
            Fullname = data.Fullname,
            Email = data.Email,
            Username = data.Username,
            Status = data.Status,
            DateAdded = data.DateAdded,
            RoleId = data.RoleId,
            RoleName = data.Role.RoleName
        };
        return result;
    }
}
