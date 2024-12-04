using HRE.Application.DTOs.GiftRule;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftRuleService
{
    Task<GiftRule?> Create(GiftRuleDTO entity);
    Task<bool> Update(int id, GiftRuleDTO entity);
    Task<bool> Delete(int id);

    Task<PaginatedModel<GetRuleDTO>> GetAll(QueryModel query);

    Task<GetRuleDTO?> GetByID(int id);

    // Thêm phần quà vô quy tắc
    Task<GiftInRule?> CreateGiftInRule(int ruleID, GiftInRuleDTO entity);

    Task<bool> UpdateGiftInRule(int id, GiftInRuleDTO entity);

    Task<bool> DeleteGiftInRule(int id);

    // Thông tin quà trong quy tắc

    Task<IEnumerable<GiftInRule>> GetGiftOfRule(int ruleID);
}
