using HRE.Application.DTOs.Permission;
using HRE.Application.Interfaces;
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


    }
}
