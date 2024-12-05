using HRE.Application.DTOs.Permission;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }
        [RequiredPermission("Tạo vai trò mới")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PermissionDTO entity)
        {
            var result = await permissionService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin vai trò")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id,[FromBody] PermissionDTO entity)
        {
            var result = await permissionService.Update(id,entity);
           
            return result ? NoContent(): BadRequest();
        }
        [RequiredPermission("Xóa vai trò")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await permissionService.Delete(id);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách vai trò")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<Permission>>> Get([FromQuery] QueryModel query)
        {
            return Ok(await permissionService.GetAll(query));
        }
        [RequiredPermission("Xem chi tiết thông tin vai trò")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetByID([FromRoute]int id)
        {
            var result = await permissionService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
        [RequiredPermission("Tạo vai trò mới")]
        // Group
        [HttpPost("/api/groups")]
        public async Task<ActionResult> CreateGroup([FromBody] GroupDTO entity)
        {
            var result = await permissionService.CreateGroup(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin vai trò")]
        [HttpPut("/api/groups/{id}")]
        public async Task<ActionResult> UpdateGroup([FromRoute] int id, [FromBody] GroupDTO entity)
        {
            var result = await permissionService.UpdateGroup(id, entity);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa vai trò")]
        [HttpDelete("/api/groups/{id}")]
        public async Task<ActionResult> DeleteGroup([FromRoute] int id)
        {
            var result = await permissionService.DeleteGroup(id);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách vai trò")]
        [HttpGet("/api/groups")]
        public async Task<ActionResult<IEnumerable<PermissionGroup>>> GetGroup([FromQuery]QueryModel query)
        {
            return Ok(await permissionService.GetAllGroup(query));
        }
        [RequiredPermission("Xem chi tiết thông tin vai trò")]
        [HttpGet("/api/groups/{id}")]
        public async Task<ActionResult<Permission>> GetGroupByID([FromRoute] int id)
        {
            var result = await permissionService.GetGroupByID(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
