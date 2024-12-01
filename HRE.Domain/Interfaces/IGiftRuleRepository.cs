
using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IGiftRuleRepository
{
    Task<GiftRule?> Create(GiftRule entity);

    Task<bool> Update(GiftRule entity);

    Task<bool> Delete(int id);

    Task<GiftRule?> GetByID(int id);

    Task<List<GiftRule>> GetAll();

    Task<GiftRule?> GetRuleQueryByID(int id);

    // Sử lý phần quà trong quy tắc
    Task<GiftInRule?> CreateGiftInRule(GiftInRule entity);

    Task<bool> UpdateGiftInRule(GiftInRule entity);

    Task<GiftInRule?> GetGiftInRuleByID(int id);

    Task<List<GiftInRule>> GetGiftsInRule();
    Task<bool> DeleteGiftInRule(int id);
}
