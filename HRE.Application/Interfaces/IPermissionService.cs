using HRE.Application.DTOs.Permission;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IPermissionService
{
    Task<Permission?> Create(PermissionDTO entity);

    Task<bool> Update(int id, PermissionDTO entity);

    Task<bool> Delete(int id);

    Task<Permission?> GetByID(int id);

    Task<IEnumerable<Permission>> GetAll();

    Task<PermissionGroup?> CreateGroup(GroupDTO entity);

    Task<bool> UpdateGroup(int id, GroupDTO entity);

    Task<bool> DeleteGroup(int id);

    Task<PermissionGroup?> GetGroupByID(int id);

    Task<IEnumerable<PermissionGroup>> GetAllGroup();
}
