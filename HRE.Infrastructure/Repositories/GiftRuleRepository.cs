using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

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
        return await context.GiftRules
            .Include(x=>x.GiftInRules).ThenInclude(x=>x.CampaignGiftRules)
            .ToListAsync();
    }

    public async Task<GiftRule?> GetByID(int id)
    {
        return await context.GiftRules.FindAsync(id);
    }

    public async Task<GiftRule?> GetRuleQueryByID(int id)
    {
        return await context.GiftRules
          .Include(x => x.GiftInRules).ThenInclude(x => x.CampaignGiftRules)
          .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<bool> Update(GiftRule entity)
    {
        context.GiftRules.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
    // Sử lý phần quà trong quy tắc

    public async Task<GiftInRule?> CreateGiftInRule(GiftInRule entity)
    {
        await context.GiftInRules.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;
        return null;
    }


    public async Task<bool> UpdateGiftInRule(GiftInRule entity)
    {
        context.GiftInRules.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<GiftInRule?> GetGiftInRuleByID(int id)
    {
        return await context.GiftInRules.FindAsync(id);
    }
    public async Task<List<GiftInRule>> GetGiftsInRule()
    {
        return await context.GiftInRules.ToListAsync();
    }

    public async Task<bool> DeleteGiftInRule(int id)
    {
        var entityToDelete = await context.GiftInRules.FindAsync(id);
        if (entityToDelete == null) return false;
        context.GiftInRules.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }


}
