using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRE.Infrastructure.Repositories;

public class CampaignRepository:ICampaignRepository
{
    private readonly AppDbContext context;
    private IDbContextTransaction? transaction;

    public CampaignRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Campaign?> Create(Campaign entity)
    {
        await context.Campaigns.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Campaigns.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Campaigns.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Campaign>> GetAll()
    {
        return await context.Campaigns.ToListAsync();
    }

    public async Task<Campaign?> GetByID(int id)
    {
        return await context.Campaigns.FindAsync(id);
    }

    public async Task<bool> Update(Campaign entity)
    {
        context.Campaigns.Update(entity);
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

    // ROBOT
    public async Task<RobotCampaign?> AddRobotToCampaign(RobotCampaign entity)
    {
        await context.RobotCampaigns.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;
        return null;
    }

    public async Task<bool> RemoveRobotFromCampaign(int campaignID, int robotID)
    {
        var entity = await context.RobotCampaigns.FirstOrDefaultAsync(x => x.RobotId == robotID && x.CampaignId == campaignID);
        if (entity == null) return false;
        context.RobotCampaigns.Remove(entity);
        return await context.SaveChangesAsync()>0;
    }

    // Machine

    public async Task<MachineCampaign?> AddRMToCampaign(MachineCampaign entity)
    {
        await context.MachineCampaigns.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;
        return null;
    }

    public async Task<bool> RemoveRMFromCampaign(int campaignID, int machineID)
    {
        var entity = await context.MachineCampaigns.FirstOrDefaultAsync(x => x.MachineId == machineID && x.CampaignId == campaignID);
        if (entity == null) return false;
        context.MachineCampaigns.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    // GIFT
    public async Task<CampaignGiftRule?> AddGiftToCampaign(CampaignGiftRule entity)
    {
        await context.CampaignGiftRules.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;
        return null;
    }
    public async Task<bool> UpdateGiftFromCampaign(CampaignGiftRule entity)
    {
        context.CampaignGiftRules.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<bool> RemoveGiftFromCampaign(int id)
    {
        var entityToDelete = await context.CampaignGiftRules.FindAsync(id);
        if (entityToDelete == null) return false;
        context.CampaignGiftRules.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<CampaignGiftRule?> GetGiftByID(int id)
    {
        return await context.CampaignGiftRules.FindAsync(id);
    }

    // VAN HANH CHIEN DICH
    public async Task<List<GiftRule>> GetRuleForCampaign()
    {
        return await context.GiftRules
            .Include(x=>x.GiftInRules).ThenInclude(x=>x.CampaignGiftRules).ToListAsync();
    }
}
