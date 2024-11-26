
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class RMRepository : IRMRepository
{
    private readonly AppDbContext context;

    public RMRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<RecyclingMachine> Create(RecyclingMachine entity)
    {
        await context.RecyclingMachines.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        var rm = await context.RecyclingMachines.FindAsync(id);
        if (rm == null) return false;
        context.RecyclingMachines.Remove(rm);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<RecyclingMachine>> GetAll()
    {
        return await context.RecyclingMachines.ToListAsync();
    }

    public async Task<RecyclingMachine?> GetByID(int id)
    {
        return await context.RecyclingMachines.FindAsync(id);
    }

    public async Task<bool> Update(RecyclingMachine entity)
    {
        var entityToUpdate = await context.RecyclingMachines.FindAsync(entity.Id);
        if (entityToUpdate == null) return false;

        context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

        return await context.SaveChangesAsync() > 0;
    }
}
