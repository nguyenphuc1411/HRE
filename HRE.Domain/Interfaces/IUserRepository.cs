using HRE.Domain.Entities;
using System.Linq.Expressions;

namespace HRE.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> Create(User entity);

    Task<bool> Update(User entity);

    Task<bool> Delete(int id);

    Task<User?> GetByID(int id);

    Task<User?> GetByCondition(Expression<Func<User, bool>> predicate);

    Task<List<User>> GetsByCondition(Expression<Func<User, bool>> predicate);

    Task<List<User>> GetAll();
    Task<User?> GetByIDQuery(int id);
    Task<User?> GetPermissions(int id);

}
