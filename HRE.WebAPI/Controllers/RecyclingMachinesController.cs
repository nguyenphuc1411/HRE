using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclingMachinesController : ControllerBase
    {
        private readonly IRecyclingMachineService recyclingMachineService;

        public RecyclingMachinesController(IRecyclingMachineService recyclingMachineService)
        {
            this.recyclingMachineService = recyclingMachineService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRMDTO entity)
        {
            var result = await recyclingMachineService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
            /*return CreatedAtAction(nameof(GetByID), new { id = result.Id }, result);*/
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id,[FromBody] UpdateRMDTO entity)
        {
            if(id!=entity.Id) return BadRequest();
            bool result = await recyclingMachineService.Update(entity);
            return result ? NoContent(): BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            bool result = await recyclingMachineService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await recyclingMachineService.GetAll();
            return Ok(result);
        }
    }
}
