﻿using HRE.Application.DTOs.Role;
using HRE.Application.Interfaces;
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
    }
}
