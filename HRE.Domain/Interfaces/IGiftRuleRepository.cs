
using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IGiftRuleRepository
{
    Task<GiftRule?> Create(GiftRule entity);

    Task<bool> Update(GiftRule entity);

    Task<bool> Delete(int id);

    Task<GiftRule?> GetByID(int id);

    Task<List<GiftRule>> GetAll();
}
