using HRE.Application.DTOs.Permission;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
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
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PermissionDTO entity)
        {
            var result = await permissionService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id,[FromBody] PermissionDTO entity)
        {
            var result = await permissionService.Update(id,entity);
           
            return result ? NoContent(): BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await permissionService.Delete(id);

            return result ? NoContent() : BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<Permission>>> Get()
        {
            return Ok(await permissionService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetByID([FromRoute]int id)
        {
            var result = await permissionService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }


        // Group
        [HttpPost("/api/groups")]
        public async Task<ActionResult> CreateGroup([FromBody] GroupDTO entity)
        {
            var result = await permissionService.CreateGroup(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut("/api/groups/{id}")]
        public async Task<ActionResult> UpdateGroup([FromRoute] int id, [FromBody] GroupDTO entity)
        {
            var result = await permissionService.UpdateGroup(id, entity);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("/api/groups/{id}")]
        public async Task<ActionResult> DeleteGroup([FromRoute] int id)
        {
            var result = await permissionService.DeleteGroup(id);

            return result ? NoContent() : BadRequest();
        }

        [HttpGet("/api/groups")]
        public async Task<ActionResult<List<PermissionGroup>>> GetGroup()
        {
            return Ok(await permissionService.GetAllGroup());
        }
        [HttpGet("/api/groups/{id}")]
        public async Task<ActionResult<Permission>> GetGroupByID([FromRoute] int id)
        {
            var result = await permissionService.GetGroupByID(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
