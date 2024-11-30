using HRE.Application.DTOs.GiftRule;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftRuleService
{
    Task<GiftRule?> Create(GiftRuleDTO entity);
    Task<bool> Update(int id, GiftRuleDTO entity);
    Task<bool> Delete(int id);
}
