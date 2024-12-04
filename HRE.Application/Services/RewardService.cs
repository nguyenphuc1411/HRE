using AutoMapper;
using HRE.Application.DTOs.Reward;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RewardService : IRewardService
{
    private readonly IBaseRepository<Reward> rewardRepository;
    private readonly IMapper mapper;
    public RewardService(IBaseRepository<Reward> rewardRepository, IMapper mapper)
    {
        this.rewardRepository = rewardRepository;
        this.mapper = mapper;
    }

    public async Task<Reward?> Create(RewardDTO entity)
    {
        var reward = mapper.Map<Reward>(entity);
        await rewardRepository.AddAsync(reward);
        var result = await rewardRepository.SaveChangesAsync();
        return result>0?reward:null;
    }


}
