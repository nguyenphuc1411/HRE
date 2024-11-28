using HRE.Application.DTOs.Role;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRoleService
{
    Task<Role> Create(RoleDTO entity);
    Task<bool> Update(int id, RoleDTO entity);
    Task<bool> Delete(int id);
}
