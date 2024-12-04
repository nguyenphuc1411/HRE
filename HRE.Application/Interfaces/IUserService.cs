
using HRE.Application.DTOs.User;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IUserService
{
    Task<User?> Create(UserDTO entity);

    Task<bool> Update(int id,UserDTO entity);

    Task<bool> Delete(int id);

    Task<GetUserDTO?> GetById(int id);

    Task<PaginatedModel<GetUserDTO>> Get(QueryModel query);

    Task<IEnumerable<string>> GetRolePermissions(int userId);
}
