using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class RoleRepository:IRoleRepository
{
    private readonly AppDbContext context;

    public RoleRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Role?> Create(Role entity)
    {
        await context.Roles.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Roles.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Roles.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Role>> GetAll()
    {
        return await context.Roles.ToListAsync();
    }

    public async Task<Role?> GetByID(int id)
    {
        return await context.Roles.FindAsync(id);
    }

    public async Task<bool> Update(Role entity)
    {
        context.Roles.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }

    // SỬ LÝ VỀ ROLE PERMISSION
    public async Task<RolePermission?> AddPermission(RolePermission entity)
    {
        await context.RolePermissions.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;
        return null;
    }

    public async Task<bool> DeletePermission(int roleID, int permissionID)
    {
        var entityToDelete = await context.RolePermissions.FirstOrDefaultAsync(x=>x.RoleId==roleID&&x.PermissionId==permissionID);
        if (entityToDelete == null) return false;
        context.RolePermissions.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }
}
