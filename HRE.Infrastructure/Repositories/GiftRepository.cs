using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class GiftRepository:IGiftRepository
{
    private readonly AppDbContext context;

    public GiftRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Gift> Create(Gift entity)
    {
        await context.Gifts.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Gifts.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Gifts.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Gift>> GetAll()
    {
        return await context.Gifts.ToListAsync();
    }

    public async Task<Gift?> GetByID(int id)
    {
        return await context.Gifts.FindAsync(id);
    }

    public async Task<bool> Update(Gift entity)
    {
        context.Gifts.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}
