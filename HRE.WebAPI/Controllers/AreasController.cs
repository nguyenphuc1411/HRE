using HRE.Application.DTOs.Area;
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
    public class AreasController : ControllerBase
    {
        private readonly IAreaService areaService;

        public AreasController(IAreaService areaService)
        {
            this.areaService = areaService;
        }
        [RequiredPermission("Tạo khu vực mới")]
        [HttpPost]
        public async Task<ActionResult<Area>> Create([FromBody] AreaDTO entity)
        {
            var result = await areaService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin khu vực")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AreaDTO entity)
        {
            bool result = await areaService.Update(id,entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa khu vực")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await areaService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách khu vực")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GetAreaDTO>>> Get([FromQuery] QueryModel query)
        {
            var result = await areaService.GetAll(query);
            return Ok(result);
        }
        [RequiredPermission("Xem chi tiết thông tin khu vực")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAreaDTO>> GetByID([FromRoute]int id)
        {
            var result = await areaService.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
