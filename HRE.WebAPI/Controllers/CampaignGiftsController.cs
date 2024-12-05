using HRE.Application.DTOs.Campaign;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.WebAPI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignGiftsController : ControllerBase
    {
        private readonly ICampaignGiftService service;

        public CampaignGiftsController(ICampaignGiftService service)
        {
            this.service = service;
        }

        [HttpGet("{campaignID}/gifts")]
        public async Task<ActionResult<IEnumerable<CampaignGift>>> GetGiftsFromCampaign([FromRoute] int campaignID)
        {
            var result = await service.GetCampaignGifts(campaignID);
            return Ok(result);
        }

        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CampaignGiftDTO campaignGiftRuleDTO)
        {
            var result = await service.Create(campaignGiftRuleDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] CampaignGiftDTO campaignGiftRuleDTO)
        {
            bool result = await service.Update(id, campaignGiftRuleDTO);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            bool result = await service.Delete(id);

            return result ? NoContent() : BadRequest();
        }
    }
}
