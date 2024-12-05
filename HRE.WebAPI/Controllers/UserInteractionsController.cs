using HRE.Application.DTOs.UserInteraction;
using HRE.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInteractionsController : ControllerBase
    {
        private readonly IUserInteractionService service;

        public UserInteractionsController(IUserInteractionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<UserInteractionsController>> Start([FromBody] StartUserInteractionDTO startUserInteraction)
        {
            var result = await service.StartInteraction(startUserInteraction);
            if (result == null) return BadRequest();
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<UserInteractionsController>> Finish([FromBody] FinishInteractionDTO finishInteraction)
        {
            var result = await service.FinishInteraction(finishInteraction);
            return Ok(result);
        }
    }
}
