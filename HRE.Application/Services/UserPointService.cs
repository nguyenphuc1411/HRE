using AutoMapper;
using HRE.Application.DTOs.UserPoint;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class UserPointService : IUserPointService
{
    private readonly IBaseRepository<UserPoint> userPointRepository;
    private readonly IMapper mapper;

    public UserPointService(IBaseRepository<UserPoint> userPointRepository, IMapper mapper)
    {
        this.userPointRepository = userPointRepository;
        this.mapper = mapper;
    }

    public async Task<UserPoint?> CreateOrUpdate(UserPointDTO entity)
    {
        var data = await userPointRepository.FindAsync(x => x.UserId == entity.UserId && x.CampaignId == entity.CampaignId);
        if (data==null)
        {
            // tao moi
            var userpoint = mapper.Map<UserPoint>(entity);
            await userPointRepository.AddAsync(userpoint);
            var result = await userPointRepository.SaveChangesAsync();
            return result>0? userpoint:null;
        }
        else
        {
            // cap nhat
            data.Points = entity.Points;
            data.LastUpdated = DateTime.UtcNow;
            userPointRepository.Update(data);
            var result = await userPointRepository.SaveChangesAsync();
            return result > 0 ? data : null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await userPointRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        userPointRepository.Delete(entityToDelete);
        return await userPointRepository.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<UserPoint>> Get()
    {
        return await userPointRepository.GetAllAsync();
    }
}
