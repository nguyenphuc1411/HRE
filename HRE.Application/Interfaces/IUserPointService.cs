
using HRE.Application.DTOs.UserPoint;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IUserPointService
{
    Task<UserPoint?> CreateOrUpdate(UserPointDTO entity);

    Task<bool> Delete(int id);  

    Task<IEnumerable<UserPoint>> Get();
}
