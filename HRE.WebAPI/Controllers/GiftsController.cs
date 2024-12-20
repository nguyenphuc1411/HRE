﻿using HRE.Application.DTOs.Gift;
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
    public class GiftsController : ControllerBase
    {
        private readonly IGiftService giftService;

        public GiftsController(IGiftService giftService)
        {
            this.giftService = giftService;
        }
        [RequiredPermission("Tạo quà tặng mới")]
        [HttpPost]
        public async Task<ActionResult<Gift>> Create([FromBody] GiftDTO entity)
        {
            var result = await giftService.Create(entity);
            if (result == null) return BadRequest();

            return Ok(result);
        }
        [RequiredPermission("Cập nhật thông tin quà tặng")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiftDTO entity)
        {
            bool result = await giftService.Update(id, entity);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xóa quà tặng")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool result = await giftService.Delete(id);
            return result ? NoContent() : BadRequest();
        }
        [RequiredPermission("Xem danh sách quà tặng")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryModel query)
        {
            return Ok(await giftService.Get(query));
        }
        [RequiredPermission("Xem chi tiết thông tin quà tặng")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var result = await giftService.GetByID(id);
            if(result== null) return NotFound();
            return Ok(result);
        }
    }
}
