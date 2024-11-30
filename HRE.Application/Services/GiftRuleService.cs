

using AutoMapper;
using HRE.Application.DTOs.GiftRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class GiftRuleService : IGiftRuleService
{
    private readonly IGiftRuleRepository repository;
    private readonly IMapper mapper;
    public GiftRuleService(IGiftRuleRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<GiftRule?> Create(GiftRuleDTO entity)
    {
        var newEntity = mapper.Map<GiftRule>(entity);

        newEntity.GiftInRules = new List<GiftInRule>();

        foreach (var item in entity.GiftInRuleDTOs)
        {
            newEntity.GiftInRules.Add(new GiftInRule
            {
                GiftId = item.GiftId,
                Probability = item.Probability,
            });
        };
        var result = await repository.Create(newEntity);
        return result;
    }
    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(int id, GiftRuleDTO entity)
    {
        throw new NotImplementedException();
    }
}
