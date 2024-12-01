
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly AppDbContext context;

    public LocationRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Location?> Create(Location entity)
    {
        await context.Locations.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if (result > 0) return entity;

        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Locations.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Locations.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Location>> GetAll()
    {
        return await context.Locations
            .Include(x => x.Campaigns).ThenInclude(c => c.RobotCampaigns)
            .Include(x => x.Campaigns).ThenInclude(c => c.MachineCampaigns)
            .Include(x => x.Area) 
            .ToListAsync();
    }

    public async Task<Location?> GetByID(int id)
    {
        return await context.Locations
            .Include(x=>x.Campaigns).ThenInclude(x=>x.RobotCampaigns).ThenInclude(x => x.Robot)
            .Include(x=>x.Campaigns).ThenInclude(x=>x.MachineCampaigns).ThenInclude(x => x.Machine)
            .Include(x=>x.Area)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<bool> Update(Location entity)
    {
        context.Locations.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}
