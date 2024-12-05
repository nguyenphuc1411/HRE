using HRE.Application.DTOs.Role;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Application.Services;
using HRE.Domain.Entities;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RolesController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        [RequiredPermission("Tạo vai trò mới")]
        [HttpPost]
        public async Task<ActionResult<Role>> Create([FromBody] RoleDTO entity)
        {
            var result = await roleService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin vai trò")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDTO entity)
        {
            bool result = await roleService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa vai trò")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await roleService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách vai trò")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GetRoleDTO>>> Get([FromQuery] QueryModel query)
        {
            var result = await roleService.Get(query);
            return Ok(result);
        }
        [RequiredPermission("Xem chi tiết thông tin vai trò")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRoleDTO>> GetByID([FromRoute] int id)
        {
            var result = await roleService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [RequiredPermission("Cập nhật thông tin vai trò")]
        // Sử lý các quyền cho role

        [HttpGet("{roleID}/permissions")]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissionsOfRole([FromRoute]int roleID)
        {
            return Ok(await roleService.GetPermissionOfRole(roleID));
        }


        [HttpPost("{roleID}/perimssions")]
        public async Task<IActionResult> AddPermissionForRole([FromRoute] int roleID, [FromBody] List<int> permissionIDs)
        {
            bool result = await roleService.AddPermission(roleID, permissionIDs);
            return result?  Ok(): BadRequest();
        }
        [RequiredPermission("Cập nhật thông tin vai trò")]
        [HttpDelete("{roleID}/perimssions")]
        public async Task<IActionResult> DeletePermissionForRole([FromRoute] int roleID, [FromBody] List<int> permissionIDs)
        {
            var result = await roleService.DeletePermission(roleID, permissionIDs);
            return result ? NoContent(): BadRequest();
        }
    }
}
