using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class GiftRuleRepository : IGiftRuleRepository
{
    private readonly AppDbContext context;

    public GiftRuleRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<GiftRule?> Create(GiftRule entity)
    {
        await context.GiftRules.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.GiftRules.FindAsync(id);
        if (entityToDelete == null) return false;
        context.GiftRules.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<GiftRule>> GetAll()
    {
        return await context.GiftRules.ToListAsync();
    }

    public async Task<GiftRule?> GetByID(int id)
    {
        return await context.GiftRules.FindAsync(id);
    }

    public async Task<bool> Update(GiftRule entity)
    {
        context.GiftRules.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}
