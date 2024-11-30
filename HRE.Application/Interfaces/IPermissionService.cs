using HRE.Application.DTOs.Permission;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IPermissionService
{
    Task<Permission?> Create(PermissionDTO entity);

    Task<bool> Update(int id, PermissionDTO entity);

    Task<bool> Delete(int id);

    Task<PermissionGroup?> CreateGroup(GroupDTO entity);

    Task<bool> UpdateGroup(int id, GroupDTO entity);

    Task<bool> DeleteGroup(int id);
}
