using HRE.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRE.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly IRewardService rewardService;

        public RewardsController(IRewardService rewardService)
        {
            this.rewardService = rewardService;
        }


    }
}
