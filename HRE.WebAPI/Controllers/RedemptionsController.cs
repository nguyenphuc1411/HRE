using HRE.Application.DTOs.GiftRedemption;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedemptionsController : ControllerBase
    {
        private readonly IGiftRedemptionService service;

        public RedemptionsController(IGiftRedemptionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<GiftRedemption>> Create([FromBody] RedemptionDTO redemptionDTO)
        {
            var result = await service.Create(redemptionDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpPost("return")]
        public async Task<ActionResult<GiftRedemption>> ReturnGift([FromBody] ReturnDTO returnDTO)
        {
            var result = await service.ReturnGift(returnDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }

}
