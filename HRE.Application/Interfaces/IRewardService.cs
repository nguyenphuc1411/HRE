using HRE.Application.DTOs.Reward;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRewardService
{
    Task<Reward?> Create(RewardDTO entity);
}
