using HRE.Application.DTOs.GiftRedemption;
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
    public class RedemptionsController : ControllerBase
    {
        private readonly IGiftRedemptionService service;

        public RedemptionsController(IGiftRedemptionService service)
        {
            this.service = service;
        }
        [RequiredPermission("PG")]
        [HttpPost]
        public async Task<ActionResult<GiftRedemption>> Create([FromBody] RedemptionDTO redemptionDTO)
        {
            var result = await service.Create(redemptionDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<PaginatedModel<GiftRedemption>>> GetHistoryRedemption([FromQuery]QueryModel query)
        {
            var result = await service.GetHistoryRedemption(query);
            return Ok(result);
        }

        [HttpGet("return")]
        public async Task<ActionResult<PaginatedModel<GiftRedemption>>> GetHistoryReturn([FromQuery] QueryModel query)
        {
            var result = await service.GetHistoryReturn(query);
            return Ok(result);
        }

        [RequiredPermission("PG")]
        [HttpPost("return")]
        public async Task<ActionResult<GiftRedemption>> ReturnGift([FromBody] ReturnDTO returnDTO)
        {
            var result = await service.ReturnGift(returnDTO);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }

}
