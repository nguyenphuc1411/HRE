using HRE.Application.DTOs.CampaignRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignRulesController : ControllerBase
    {
        private readonly ICampaignRuleService service;

        public CampaignRulesController(ICampaignRuleService service)
        {
            this.service = service;
        }
        [RequiredPermission("Xem thông tin trúng thưởng của quà tặng")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignRuleDTO>>> Get()
        {
            return Ok(await service.GetAllCampaignRule());
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpGet("campaigns/{campaignID}")]
        public async Task<ActionResult<IEnumerable<int>>> GetRulesOfCampaign([FromRoute]int campaignID)
        {
            return Ok(await service.GetRulesOfCampaign(campaignID));
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpPost]
        public async Task<ActionResult<CampaignRule>> Create([FromBody]CampaignRuleDTO campaignRule)
        {
            var result = await service.Create(campaignRule);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpPost("multiple")]
        public async Task<ActionResult<IEnumerable<CampaignRule>>> CreateMultiple([FromBody] IEnumerable<CampaignRuleDTO> campaignRules)
        {
            if(campaignRules.Count()==0) return BadRequest("Count of list must be greater than 0");
            var result = await service.CreateMultiple(campaignRules);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] CampaignRuleDTO campaignRule)
        {
            var result = await service.Delete(campaignRule);
            return result ? NoContent(): BadRequest();
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpDelete("multiple")]
        public async Task<ActionResult> DeleteMultiple([FromBody] IEnumerable<CampaignRuleDTO> campaignRules)
        {
            if (campaignRules.Count() == 0) return BadRequest("Count of list must be greater than 0");
            var result = await service.DeleteMultiple(campaignRules);
            return result ? NoContent() : BadRequest();
        }
    }
}
