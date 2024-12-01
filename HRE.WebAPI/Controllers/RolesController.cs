using HRE.Application.DTOs.Role;
using HRE.Application.Interfaces;
using HRE.Application.Services;
using HRE.Domain.Entities;
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

        [HttpPost]
        public async Task<ActionResult<Role>> Create([FromBody] RoleDTO entity)
        {
            var result = await roleService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoleDTO entity)
        {
            bool result = await roleService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await roleService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRoleDTO>>> Get()
        {
            var result = await roleService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRoleDTO>> GetByID([FromRoute] int id)
        {
            var result = await roleService.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        // THÊM QUYỀN CHO ROLE VÀ XÓA QUYỀN
        [HttpPost("{roleID}/perimssions")]
        public async Task<IActionResult> AddPermissionForRole([FromRoute] int roleID, [FromBody] List<int> permissionIDs)
        {
            bool result = await roleService.AddPermission(roleID, permissionIDs);
            return result?  Ok(): BadRequest();
        }
        [HttpDelete("{roleID}/perimssions")]
        public async Task<IActionResult> DeletePermissionForRole([FromRoute] int roleID, [FromBody] List<int> permissionIDs)
        {
            var result = await roleService.DeletePermission(roleID, permissionIDs);
            return result ? NoContent(): BadRequest();
        }
    }
}
