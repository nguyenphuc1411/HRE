using AutoMapper;
using HRE.Application.DTOs.UserPoint;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class UserPointService : IUserPointService
{
    private readonly IUserPointRepository userPointRepository;
    private readonly IMapper mapper;

    public UserPointService(IUserPointRepository userPointRepository, IMapper mapper)
    {
        this.userPointRepository = userPointRepository;
        this.mapper = mapper;
    }

    public async Task<UserPoint?> CreateOrUpdate(UserPointDTO entity)
    {
        return await userPointRepository.CreateOrUpdate(mapper.Map<UserPoint>(entity));
    }

    public async Task<bool> Delete(int id)
    {
        return await userPointRepository.Delete(id);
    }

    public async Task<List<UserPoint>> Get()
    {
        return await userPointRepository.GetAll();
    }
}
