using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRE.Infrastructure.Repositories;

public class UserPointRepository : IUserPointRepository
{
    private readonly AppDbContext context;

    public UserPointRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<UserPoint?> CreateOrUpdate(UserPoint entity)
    {
       var check = await context.UserPoints.FirstOrDefaultAsync(x=>x.UserId==entity.UserId&&x.CampaignId==entity.CampaignId);
       if (check == null)
        {
            // tao moi
            await context.UserPoints.AddAsync(entity);
            var result = await context.SaveChangesAsync();
            if(result>0) return entity;
            return null;
        }
        else
        {
            // cap nhat
            check.Points = entity.Points;
            check.LastUpdated= DateTime.UtcNow;
            context.UserPoints.Update(check);  
            var result = await context.SaveChangesAsync();
            if(result>0) return check;
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await context.UserPoints.FindAsync(id);
        if (entityToDelete == null) return false;
        context.UserPoints.Remove(entityToDelete);
        return await context.SaveChangesAsync()>0;
    }

    public async Task<List<UserPoint>> GetAll()
    {
       return await context.UserPoints.ToListAsync();
    }
    public async Task<UserPoint?> GetByCondition(Expression<Func<UserPoint, bool>> condition)
    {
        return await context.UserPoints.FirstOrDefaultAsync(condition);
    }
}
