
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRE.Infrastructure.Repositories;

public class UserRepository:IUserRepository
{
    private readonly AppDbContext context;
    public UserRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Users.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Users.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(User entity)
    {
        context.Users.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<User?> Create(User entity)
    {
        await context.Users.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }

    public async Task<User?> GetByID(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<User?> GetByCondition(Expression<Func<User, bool>> predicate)
    {
        return await context.Users.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetsByCondition(Expression<Func<User, bool>> predicate)
    {
        return await context.Users.Where(predicate).ToListAsync();
    }
}
