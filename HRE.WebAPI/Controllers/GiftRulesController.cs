using HRE.Application.DTOs.GiftRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftRulesController : ControllerBase
    {
        private readonly IGiftRuleService giftRuleService;

        public GiftRulesController(IGiftRuleService giftRuleService)
        {
            this.giftRuleService = giftRuleService;
        }

        [HttpPost]
        public async Task<ActionResult<GiftRule>> Create([FromBody] GiftRuleDTO entity)
        {
            var result = await giftRuleService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftRuleDTO entity)
        {
            bool result = await giftRuleService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await giftRuleService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
    }
}
