using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRE.Infrastructure.Repositories;

public class RoleRepository:IRoleRepository
{
    private readonly AppDbContext context;
    private IDbContextTransaction? transaction;
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
        return await context.Roles.Include(x=>x.Users).ToListAsync();
    }
    public async Task<Role?> GetByIDQuery(int id)
    {
        return await context.Roles.Include(x=>x.Users).FirstOrDefaultAsync(x=>x.Id==id);
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



    // Begin Transaction
    public async Task BeginTransaction()
    {
        if (transaction == null)
        {
            transaction = await context.Database.BeginTransactionAsync();
        }
    }

    // Commit Transaction
    public async Task CommitTransaction()
    {
        if (transaction != null)
        {
            await transaction.CommitAsync();
            await transaction.DisposeAsync();
            transaction = null;
        }
    }

    // Rollback Transaction
    public async Task RollbackTransaction()
    {
        if (transaction != null)
        {
            await transaction.RollbackAsync();
            await transaction.DisposeAsync();
            transaction = null;
        }
    }
}
