using HRE.Application.DTOs.GiftRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        [HttpGet]
        public async Task<ActionResult<List<GetRuleDTO>>> GetAll()
        {
            return Ok(await giftRuleService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRuleDTO>> GetByID([FromRoute]int id)
        {
            var result = await giftRuleService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }


        // Sử lý thông tin phần quà trong quy tắc
        [HttpPost("{ruleID}/gifts")]
        public async Task<ActionResult<GiftInRule>> CreateGiftInRule([FromRoute] int ruleID,[FromBody] GiftInRuleDTO entity)
        {
            var result = await giftRuleService.CreateGiftInRule(ruleID,entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [HttpPut("gifts/{id}")]
        public async Task<ActionResult> UpdateGiftInRule([FromRoute] int id, [FromBody] GiftInRuleDTO entity)
        {
            bool result = await giftRuleService.UpdateGiftInRule(id, entity);
            return result ? NoContent() : BadRequest();
        }

        [HttpDelete("gifts/{id}")]
        public async Task<IActionResult> DeleteGiftInRule([FromRoute] int id)
        {
            bool result = await giftRuleService.DeleteGiftInRule(id);
            return result ? NoContent() : BadRequest();
        }

        // Thông tin quà trong 1 quy tắc

        [HttpGet("{ruleID}/gifts")]
        public async Task<ActionResult> GetGiftsOfRule([FromRoute] int ruleID)
        {
            var data = await giftRuleService.GetGiftOfRule(ruleID);
            return Ok(data);
        }
    }
}
