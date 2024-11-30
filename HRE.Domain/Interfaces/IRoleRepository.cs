
using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IRoleRepository
{
    Task<Role?> Create(Role entity);

    Task<bool> Update(Role entity);

    Task<bool> Delete(int id);

    Task<Role?> GetByID(int id);

    Task<List<Role>> GetAll();

    Task<RolePermission?> AddPermission(RolePermission entity);

    Task<bool> DeletePermission(int roleID,int permissionID);
}
