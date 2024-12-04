using HRE.Application.DTOs.Robot;
using HRE.Application.Interfaces;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotService robotService;

        public RobotsController(IRobotService robotService)
        {
            this.robotService = robotService;
        }
        [RequiredPermission("Xem danh sách Robot")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRobotDTO>>> Get()
        {
            var result = await robotService.GetAll();
            return Ok(result);
        }
        [RequiredPermission("Xem chi tiết thông tin Robot")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetRobotDTO>> GetByID([FromRoute] int id)
        {
            var result = await robotService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
        [RequiredPermission("Tạo Robot mới")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateRobotDTO robot)
        {
            var result = await robotService.Create(robot);
            if(result == null) return BadRequest();
            return CreatedAtAction(nameof(GetByID), new {id=result.Id},result);
        }
        [RequiredPermission("Cập nhật thông tin Robot")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute]int id,[FromBody] UpdateRobotDTO robot)
        {
            if(id!=robot.Id) return BadRequest();
            bool result = await robotService.Update(robot);
            return result? NoContent(): BadRequest();
        }
        [RequiredPermission("Xóa Robot")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            bool result = await robotService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
    }
}
