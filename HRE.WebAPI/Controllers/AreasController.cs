using HRE.Application.DTOs.Area;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaService areaService;

        public AreasController(IAreaService areaService)
        {
            this.areaService = areaService;
        }

        [HttpPost]
        public async Task<ActionResult<Area>> Create([FromBody] AreaDTO entity)
        {
            var result = await areaService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AreaDTO entity)
        {
            bool result = await areaService.Update(id,entity);
            return result ? NoContent() : BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await areaService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAreaDTO>>> Get()
        {
            var result = await areaService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAreaDTO>> GetByID([FromRoute]int id)
        {
            var result = await areaService.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
