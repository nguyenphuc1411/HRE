
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HRE.Infrastructure.Repositories;

public class UserTokenRepository : IUserTokenRepository
{
    private readonly AppDbContext context;
    public UserTokenRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<UserToken?> Create(UserToken entity)
    {
        await context.UserTokens.AddAsync(entity);
        var result = await context.SaveChangesAsync();
        if(result>0) return entity;
        return null;
    }
    public async Task<UserToken?> GetByCondition(Expression<Func<UserToken, bool>> predicate)
    {
        return await context.UserTokens.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<UserToken>> GetsByCondition(Expression<Func<UserToken, bool>> predicate)
    {
        return await context.UserTokens.Where(predicate).ToListAsync();
    }

    public Task<bool> Update(UserToken entity)
    {
        throw new NotImplementedException();
    }
}
