using AutoMapper;
using HRE.Application.DTOs.GiftRule;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRE.Application.Services;

public class GiftRuleService : IGiftRuleService
{
    private readonly IBaseRepository<GiftRule> giftRuleRepository;
    private readonly IBaseRepository<GiftInRule> giftInRuleRepository;
    private readonly IMapper mapper;
    public GiftRuleService(IBaseRepository<GiftRule> giftRuleRepository, IMapper mapper,
        IBaseRepository<GiftInRule> giftInRuleRepository)
    {
        this.giftRuleRepository = giftRuleRepository;
        this.mapper = mapper;
        this.giftInRuleRepository = giftInRuleRepository;
    }

    public async Task<GiftRule?> Create(GiftRuleDTO entity)
    {
        var rule = mapper.Map<GiftRule>(entity);
        await giftRuleRepository.AddAsync(rule);
        var result = await giftRuleRepository.SaveChangesAsync();
        return result > 0 ? rule : null;
    }
    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await giftRuleRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        giftRuleRepository.Delete(entityToDelete);
        return await giftRuleRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(int id, GiftRuleDTO entity)
    {
        var entityToUpdate = await giftRuleRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        giftRuleRepository.Update(entityToUpdate);

        return await giftRuleRepository.SaveChangesAsync() > 0;
    }

    public async Task<PaginatedModel<GetRuleDTO>> GetAll(QueryModel query)
    {
        return await giftRuleRepository.AsQueryable()
            .Select(x => new GetRuleDTO
            {
                Id = x.Id,
                RuleName = x.RuleName,
                DateAdded = x.DateAdded,
                MinPoints = x.MinPoints,
                MaxPoints = x.MaxPoints,
                Description = x.Description,
/*                AppliedLocationCount = x.GiftInRules
                    .SelectMany(giftInRule => giftInRule)
                    .Count() */
            })
            .ApplyQuery(query,g=>g.RuleName); 
    }
    public async Task<GetRuleDTO?> GetByID(int id)
    {
        var data = await giftRuleRepository.AsQueryable()
            .Where(x => x.Id == id)
            .Include(x => x.GiftInRules)
/*            .ThenInclude(giftInRule => giftInRule.CampaignGiftRules) */
            .FirstOrDefaultAsync();

        if (data == null) return null;

        var result = new GetRuleDTO
        {
            Id = data.Id,
            RuleName = data.RuleName,
            DateAdded = data.DateAdded,
            MinPoints = data.MinPoints,
            MaxPoints = data.MaxPoints,
            Description = data.Description,
  /*          AppliedLocationCount = data.GiftInRules
                .SelectMany(giftInRule => giftInRule.CampaignGiftRules)
                .Count(),*/
        };

        return result;
    }



    // Sử lý quà trong quy tắc

    public async Task<GiftInRule?> CreateGiftInRule(int ruleID, GiftInRuleDTO entity)
    {
        var newGiftInRule = mapper.Map<GiftInRule>(entity);
        newGiftInRule.RuleId = ruleID;

        await giftInRuleRepository.AddAsync(newGiftInRule);
        var result = await giftInRuleRepository.SaveChangesAsync();
        return result > 0 ? newGiftInRule : null;
    }

    public async Task<bool> UpdateGiftInRule(int id, GiftInRuleDTO entity)
    {
        var entityToUpdate = await giftInRuleRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        giftInRuleRepository.Update(entityToUpdate);

        return await giftInRuleRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteGiftInRule(int id)
    {
        var entityToDelete = await giftInRuleRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        giftInRuleRepository.Delete(entityToDelete);
        return await giftInRuleRepository.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GiftInRule>> GetGiftOfRule(int ruleID)
    {
        return await giftInRuleRepository.FindAllAsync(x=>x.RuleId==ruleID);
    }
}
