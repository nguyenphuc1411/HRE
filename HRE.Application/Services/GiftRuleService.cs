using AutoMapper;
using HRE.Application.DTOs.GiftRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class GiftRuleService : IGiftRuleService
{
    private readonly IGiftRuleRepository giftRuleRepository;
    private readonly IMapper mapper;
    public GiftRuleService(IGiftRuleRepository giftRuleRepository, IMapper mapper)
    {
        this.giftRuleRepository = giftRuleRepository;
        this.mapper = mapper;
    }

    public async Task<GiftRule?> Create(GiftRuleDTO entity)
    {
        var newEntity = mapper.Map<GiftRule>(entity);
        return await giftRuleRepository.Create(newEntity);
    }
    public async Task<bool> Delete(int id)
    {
        return await giftRuleRepository.Delete(id);
    }

    public async Task<bool> Update(int id, GiftRuleDTO entity)
    {
        var entityToUpdate = await giftRuleRepository.GetByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await giftRuleRepository.Update(entityToUpdate);
    }

    public async Task<List<GetRuleDTO>> GetAll()
    {
        var data = await giftRuleRepository.GetAll();

        var result = data.Select(x =>
        {
            return new GetRuleDTO
            {
                Id = x.Id,
                RuleName = x.RuleName,
                DateAdded = x.DateAdded,
                MinPoints = x.MinPoints,
                MaxPoints = x.MaxPoints,
                Description = x.Description,
                AppliedLocationCount = x.GiftInRules
                    .SelectMany(giftInRule => giftInRule.CampaignGiftRules)
                    .Count(),
            };
        }).ToList();
        return result;
    }
    public async Task<GetRuleDTO?> GetByID(int id)
    {
        var data = await giftRuleRepository.GetRuleQueryByID(id);
        if (data == null) return null;

        var result = new GetRuleDTO
        {
            Id = data.Id,
            RuleName = data.RuleName,
            DateAdded = data.DateAdded,
            MinPoints = data.MinPoints,
            MaxPoints = data.MaxPoints,
            Description = data.Description,
            AppliedLocationCount = data.GiftInRules
                    .SelectMany(giftInRule => giftInRule.CampaignGiftRules)
                    .Count(),
        };                  
        return result;
    }


    // Sử lý quà trong quy tắc

    public async Task<GiftInRule?> CreateGiftInRule(int ruleID, GiftInRuleDTO entity)
    {
        var newGiftInRule = mapper.Map<GiftInRule>(entity);
        newGiftInRule.RuleId = ruleID;

        return await giftRuleRepository.CreateGiftInRule(newGiftInRule);
    }

    public async Task<bool> UpdateGiftInRule(int id, GiftInRuleDTO entity)
    {
        var entityToUpdate = await giftRuleRepository.GetGiftInRuleByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await giftRuleRepository.UpdateGiftInRule(entityToUpdate);
    }

    public async Task<bool> DeleteGiftInRule(int id)
    {
        return await giftRuleRepository.DeleteGiftInRule(id);
    }

    public async Task<List<GiftInRule>> GetGiftOfRule(int ruleID)
    {
        var data = await giftRuleRepository.GetGiftsInRule();
        var result = data.Where(x=>x.RuleId== ruleID).ToList();

        return result;
    }
}
