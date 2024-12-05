using HRE.Application.DTOs.Auth;
using HRE.Application.DTOs.User;
using HRE.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            string token = await authService.Login(loginDTO);
            if (string.IsNullOrEmpty(token)) return BadRequest();

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            bool result  = await authService.Register(registerDTO);
            return result ? Ok() : BadRequest();
        }
        [HttpPost("confirm-registion")]
        public async Task<ActionResult> ConfrimRegistion([FromBody] ConfirmRegistion confirmRegistion)
        {
            string token = await authService.ConfirmRegistion(confirmRegistion);
            if (string.IsNullOrEmpty(token)) return BadRequest();

            return Ok(token);
        }

        [HttpPost("request-forgot-password")]
        public async Task<ActionResult> RequestForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            bool result = await authService.RequestForgotPassword(forgotPasswordDTO);
            
            return result ? Ok() : BadRequest();
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            bool result = await authService.ResetPassword(resetPasswordDTO);

            return result ? Ok() : BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<GetUserDTO>> Get()
        {
            return await authService.Get();
        }
    }
}
