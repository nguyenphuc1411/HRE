using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext context;

    public PermissionRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Permission?> Create(Permission entity)
    {
        await context.Permissions.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }
    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Permissions.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Permissions.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<List<Permission>> GetAll()
    {
        return await context.Permissions.ToListAsync();
    }

    public async Task<Permission?> GetByID(int id)
    {
        return await context.Permissions.FindAsync(id);
    }

    public async Task<bool> Update(Permission entity)
    {
        context.Permissions.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<PermissionGroup?> CreateGroup(PermissionGroup entity)
    {
        await context.PermissionGroups.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }
    public async Task<bool> UpdateGroup(PermissionGroup entity)
    {
        context.PermissionGroups.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteGroup(int id)
    {
        var entityToDelete = await context.PermissionGroups.FindAsync(id);
        if (entityToDelete == null) return false;
        context.PermissionGroups.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<PermissionGroup?> GetGroupByID(int id)
    {
        return await context.PermissionGroups.FindAsync(id);
    }
}
