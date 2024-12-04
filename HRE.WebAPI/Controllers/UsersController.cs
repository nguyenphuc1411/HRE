using HRE.Application.DTOs.User;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [RequiredPermission("Tạo người dùng mới")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO entity)
        {
            var result = await userService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin người dùng")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id,[FromBody] UserDTO entity)
        {
            var result = await userService.Update(id,entity);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa người dùng")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await userService.Delete(id);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách người dùng")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GetUserDTO>>> Get([FromQuery] QueryModel query)
        {
            var result = await userService.Get(query);
            return Ok(result);
        }
        [RequiredPermission("Xem chi tiết thông tin người dùng")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> GetByID([FromRoute]int id)
        {
            var result = await userService.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
