using HRE.Application.DTOs.Location;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        [HttpPost]
        public async Task<ActionResult<Location>> Create([FromBody] LocationDTO entity)
        {
            var result = await locationService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody] LocationDTO entity)
        {
            bool result = await locationService.Update(id,entity);
            return result ? NoContent() : BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            bool result = await locationService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<GetLocationsDTO>> Get()
        {
            return Ok(await locationService.Get());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetLocationDTO>> GetByID([FromRoute] int id)
        {
            var result = await locationService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
    }
}
