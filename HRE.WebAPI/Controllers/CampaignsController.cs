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
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }

        [RequiredPermission("")]
        [HttpPost]
        public async Task<ActionResult<Campaign>> Create([FromBody] CampaignDTO entity)
        {
            var result = await campaignService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CampaignDTO entity)
        {
            bool result = await campaignService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await campaignService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [RequiredPermission("")]
        // ROBOT
        [HttpPost("{id}/robots")]
        public async Task<ActionResult> AddRobotsToCampaign([FromRoute]int id, [FromBody] List<int> robotIDs)
        {
            if (robotIDs == null || !robotIDs.Any())
            {
                return BadRequest(new { message = "Danh sách ID robot không được rỗng." });
            }

            bool result = await campaignService.AddRobotsToCampaign(id, robotIDs);

            return result ? Ok() : BadRequest();
        }
        [RequiredPermission("")]
        [HttpDelete("{id}/robots")]
        public async Task<ActionResult> RemoveRobotsFromCampaign([FromRoute] int id, [FromBody] List<int> robotIDs)
        {
            if (robotIDs == null || !robotIDs.Any())
            {
                return BadRequest(new { message = "Danh sách ID robot không được rỗng." });
            }

            bool result = await campaignService.RemoveRobotsFromCampaign(id, robotIDs);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("")]
        // MACHINE
        [HttpPost("{id}/recycling-machines")]
        public async Task<ActionResult> AddRMsToCampaign([FromRoute] int id, [FromBody] List<int> machineIDs)
        {
            if (machineIDs == null || !machineIDs.Any())
            {
                return BadRequest(new { message = "Danh sách ID recycling machine không được rỗng." });
            }

            bool result = await campaignService.AddRMsToCampaign(id, machineIDs);

            return result ? Ok() : BadRequest();
        }
        [RequiredPermission("")]
        [HttpDelete("{id}/recycling-machines")]
        public async Task<ActionResult> RemoveMsFromCampaign([FromRoute] int id, [FromBody] List<int> machineIDs)
        {
            if (machineIDs == null || !machineIDs.Any())
            {
                return BadRequest(new { message = "Danh sách ID recycling machine không được rỗng." });
            }

            bool result = await campaignService.RemoveRMsFromCampaign(id, machineIDs);

            return result ? NoContent() : BadRequest();
        }

        // GIFT
        [RequiredPermission("")]
        [HttpPost("{campaignID}/gifts")]
        public async Task<ActionResult> AddGiftToCampaign([FromRoute] int campaignID, [FromBody] CampaignGiftRuleDTO campaignGiftRuleDTO)
        {        
            var result = await campaignService.AddGiftToCampaign(campaignID, campaignGiftRuleDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [RequiredPermission("")]
        [HttpPut("gifts/{id}")]
        public async Task<ActionResult> AddGiftFromCampaign([FromRoute] int id, [FromBody] CampaignGiftRuleDTO campaignGiftRuleDTO)
        {         
            bool result = await campaignService.UpdateGiftInCampaign(id, campaignGiftRuleDTO);

            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("")]
        [HttpDelete("gifts/{id}")]
        public async Task<ActionResult> RemoveGiftFromCampaign([FromRoute] int id)
        {
            bool result = await campaignService.RemoveGiftInCampaign(id);

            return result ? NoContent() : BadRequest();
        }
    }
}
