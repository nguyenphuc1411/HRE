using HRE.Application.DTOs.Role;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRoleService
{
    Task<Role?> Create(RoleDTO entity);
    Task<bool> Update(int id, RoleDTO entity);
    Task<bool> Delete(int id);

    Task<PaginatedModel<GetRoleDTO>> Get(QueryModel query);
    Task<GetRoleDTO?> GetById(int id);
    // Sử lý Permission

    Task<IEnumerable<Permission>> GetPermissionOfRole(int roleID);
    Task<bool> AddPermission(int roleID,List<int> permissionIDs);

    Task<bool> DeletePermission(int roleID,List<int> permissionIDs);
}
