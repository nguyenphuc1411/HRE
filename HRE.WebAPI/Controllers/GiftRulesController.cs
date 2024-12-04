using HRE.Application.DTOs.GiftRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRE.WebAPI.Attributes;
using HRE.Application.Models;

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
        [RequiredPermission("Tạo quy tắc trúng thưởng mới")]
        [HttpPost]
        public async Task<ActionResult<GiftRule>> Create([FromBody] GiftRuleDTO entity)
        {
            var result = await giftRuleService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin quy tắc trúng thưởng")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftRuleDTO entity)
        {
            bool result = await giftRuleService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa quy tắc trúng thưởng")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await giftRuleService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách quy tắc trúng thưởng")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GetRuleDTO>>> GetAll([FromQuery] QueryModel query)
        {
            return Ok(await giftRuleService.GetAll(query));
        }
        [RequiredPermission("Xem chi tiết thông tin quy tắc trúng thưởng")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRuleDTO>> GetByID([FromRoute]int id)
        {
            var result = await giftRuleService.GetByID(id);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [RequiredPermission("Cập nhật thông tin quy tắc trúng thưởng")]
        // Sử lý thông tin phần quà trong quy tắc
        [HttpPost("{ruleID}/gifts")]
        public async Task<ActionResult<GiftInRule>> CreateGiftInRule([FromRoute] int ruleID,[FromBody] GiftInRuleDTO entity)
        {
            var result = await giftRuleService.CreateGiftInRule(ruleID,entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin quy tắc trúng thưởng")]
        [HttpPut("gifts/{id}")]
        public async Task<ActionResult> UpdateGiftInRule([FromRoute] int id, [FromBody] GiftInRuleDTO entity)
        {
            bool result = await giftRuleService.UpdateGiftInRule(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Cập nhật thông tin quy tắc trúng thưởng")]
        [HttpDelete("gifts/{id}")]
        public async Task<IActionResult> DeleteGiftInRule([FromRoute] int id)
        {
            bool result = await giftRuleService.DeleteGiftInRule(id);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem chi tiết thông tin quy tắc trúng thưởng")]
        // Thông tin quà trong 1 quy tắc

        [HttpGet("{ruleID}/gifts")]
        public async Task<ActionResult> GetGiftsOfRule([FromRoute] int ruleID)
        {
            var data = await giftRuleService.GetGiftOfRule(ruleID);
            return Ok(data);
        }
    }
}
