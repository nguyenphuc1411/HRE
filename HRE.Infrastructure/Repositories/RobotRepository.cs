
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class RobotRepository: IRobotRepository
{
    private readonly AppDbContext context;

    public RobotRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Robot> Create(Robot entity)
    {
        await context.Robots.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Robots.FindAsync(id);
        if(entityToDelete == null) return false;
        context.Robots.Remove(entityToDelete);
        return await context.SaveChangesAsync()>0;
    }

    public async Task<List<Robot>> GetAll()
    {
        return await context.Robots.ToListAsync();
    }

    public async Task<Robot?> GetByID(int id)
    {
        return await context.Robots.FindAsync(id);     
    }

    public async Task<bool> Update(Robot entity)
    {
        context.Robots.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}
