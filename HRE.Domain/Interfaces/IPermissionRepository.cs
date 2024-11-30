using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IPermissionRepository
{
    Task<Permission?> Create(Permission entity);

    Task<bool> Update(Permission entity);

    Task<bool> Delete(int id);

    Task<Permission?> GetByID(int id);

    Task<List<Permission>> GetAll();

    Task<PermissionGroup?> CreateGroup(PermissionGroup entity);

    Task<bool> UpdateGroup(PermissionGroup entity);

    Task<bool> DeleteGroup(int id);

    Task<PermissionGroup?> GetGroupByID(int id);
}
