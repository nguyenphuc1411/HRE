using HRE.Application.DTOs.Campaign;
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
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            this.campaignService = campaignService;
        }
        [RequiredPermission("Xem danh sách chiến dịch")]
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GetCampaignDTO>>> Get([FromQuery] QueryModel query)
        {
            var result = await campaignService.Get(query);
            return Ok(result);
        }
        [RequiredPermission("Xem chi tiết thông tin chiến dịch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCampaignDetailDTO>> GetByID([FromRoute] int id)
        {
            var result = await campaignService.GetByID(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [RequiredPermission("Tạo chiến dịch mới")]
        [HttpPost]
        public async Task<ActionResult<Campaign>> Create([FromBody] CampaignDTO entity)
        {
            var result = await campaignService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CampaignDTO entity)
        {
            bool result = await campaignService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa chiến dịch")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await campaignService.Delete(id);
            return result ? NoContent() : BadRequest();
        }

        [RequiredPermission("Cập nhật thông tin chiến dịch")]
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
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
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
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
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
        [RequiredPermission("Cập nhật thông tin chiến dịch")]
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
    }
}
