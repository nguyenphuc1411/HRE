using HRE.Domain.Entities;
using System.Linq.Expressions;

namespace HRE.Domain.Interfaces;

public interface IUserTokenRepository
{
    Task<UserToken?> Create(UserToken entity);

    Task<bool> Update(UserToken entity);
    Task<UserToken?> GetByCondition(Expression<Func<UserToken, bool>> predicate);

    Task<List<UserToken>> GetsByCondition(Expression<Func<UserToken, bool>> predicate);
}
