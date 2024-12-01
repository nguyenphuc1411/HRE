﻿
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Repositories;

public class AreaRepository:IAreaRepository
{
    private readonly AppDbContext context;

    public AreaRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Area?> Create(Area entity)
    {
        await context.Areas.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if(result>0) return entity;

        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.Areas.FindAsync(id);
        if (entityToDelete == null) return false;
        context.Areas.Remove(entityToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Area>> GetAll()
    {
        return await context.Areas.Include(x=>x.Locations).ToListAsync();
    }
    public async Task<Area?> GetByIDQuery(int id)
    {
        return await context.Areas.Include(x => x.Locations).FirstOrDefaultAsync(x=>x.Id==id);
    }
    public async Task<Area?> GetByID(int id)
    {
        return await context.Areas.FindAsync(id);
    }

    public async Task<bool> Update(Area entity)
    {
        context.Areas.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}
