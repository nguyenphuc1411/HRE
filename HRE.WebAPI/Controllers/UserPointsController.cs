using HRE.Application.DTOs.UserPoint;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPointsController : ControllerBase
    {
        private readonly IUserPointService userPointService;

        public UserPointsController(IUserPointService userPointService)
        {
            this.userPointService = userPointService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserPoint>> CreateOrUpdate([FromBody]UserPointDTO entity)
        {
            var result = await userPointService.CreateOrUpdate(entity);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var result = await userPointService.Delete(id);

            return result ? NoContent():BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await userPointService.Get();

            return Ok(result);
        }

    }
}
