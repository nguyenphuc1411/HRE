
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

    public async Task<Robot> Create(Robot robot)
    {
        await context.Robots.AddAsync(robot);
        await context.SaveChangesAsync();
        return robot;
    }

    public async Task<bool> Delete(int id)
    {
        var robot = await context.Robots.FindAsync(id);
        if(robot == null) return false;
        context.Robots.Remove(robot);
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

    public async Task<bool> Update(Robot robot)
    {
        var robotToUpdate = await context.Robots.FindAsync(robot.Id);
        if(robotToUpdate == null) return false;

        context.Entry(robotToUpdate).CurrentValues.SetValues(robot);

        return await context.SaveChangesAsync() > 0;
    }
}
