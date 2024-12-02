using HRE.Domain.Entities;
using System.Linq.Expressions;

namespace HRE.Domain.Interfaces;

public interface IUserPointRepository
{
    Task<UserPoint?> CreateOrUpdate(UserPoint entity);

    Task<bool> Delete(int id);

    Task<List<UserPoint>> GetAll();

    Task<UserPoint?> GetByCondition(Expression<Func<UserPoint, bool>> condition);
}
