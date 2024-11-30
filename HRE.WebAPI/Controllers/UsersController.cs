using HRE.Application.DTOs.User;
using HRE.Application.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO entity)
        {
            var result = await userService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute]int id,[FromBody] UserDTO entity)
        {
            var result = await userService.Update(id,entity);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await userService.Delete(id);

            return result ? NoContent() : BadRequest();
        }
    }
}
