
using AutoMapper;
using HRE.Application.DTOs.CampaignRule;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class CampaignRuleService : ICampaignRuleService
{
    private readonly IBaseRepository<CampaignRule> campaignRuleRepository;
    private readonly IMapper mapper;
    public CampaignRuleService(IBaseRepository<CampaignRule> campaignRuleRepository, IMapper mapper)
    {
        this.campaignRuleRepository = campaignRuleRepository;
        this.mapper = mapper;
    }

    public async Task<CampaignRule?> Create(CampaignRuleDTO entity)
    {
        var newEntity = mapper.Map<CampaignRule>(entity);

        await campaignRuleRepository.AddAsync(newEntity);
        var result = await campaignRuleRepository.SaveChangesAsync();

        return result > 0 ? newEntity : null;
    }

    public async Task<IEnumerable<CampaignRule>?> CreateMultiple(IEnumerable<CampaignRuleDTO> entities)
    {
        await campaignRuleRepository.BeginTransactionAsync();
        try
        {
            var listNewEntities = new List<CampaignRule>();
            foreach (var item in entities)
            {
                listNewEntities.Add(mapper.Map<CampaignRule>(item));
            }
            await campaignRuleRepository.AddRangeAsync(listNewEntities);
            var result = await campaignRuleRepository.SaveChangesAsync();
            if (result == listNewEntities.Count())
            {
                await campaignRuleRepository.CommitTransactionAsync();
                return listNewEntities;
            }
            else
            {
                await campaignRuleRepository.RollbackTransactionAsync();
                return null;
            }
        }
        catch (Exception ex)
        {
            await campaignRuleRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> Delete(CampaignRuleDTO entity)
    {
        var entityToDelete = await campaignRuleRepository.FindAsync(x=>x.CampaignId==entity.CampaignId&&x.RuleId==entity.RuleId);
        if (entityToDelete == null) return false;
        campaignRuleRepository.Delete(entityToDelete);
        return await campaignRuleRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteMultiple(IEnumerable<CampaignRuleDTO> entities)
    {
        await campaignRuleRepository.BeginTransactionAsync();
        try
        {
            var listNewEntities = new List<CampaignRule>();
            foreach (var item in entities)
            {
                listNewEntities.Add(mapper.Map<CampaignRule>(item));
            }
            campaignRuleRepository.DeleteRange(listNewEntities);
            var result = await campaignRuleRepository.SaveChangesAsync();
            if (result == listNewEntities.Count())
            {
                await campaignRuleRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await campaignRuleRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await campaignRuleRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<CampaignRuleDTO>> GetAllCampaignRule()
    {
        var result = await campaignRuleRepository.GetAllAsync();
        return mapper.Map<IEnumerable<CampaignRuleDTO>>(result);
    }
    public async Task<IEnumerable<int>> GetRulesOfCampaign(int campaignID)
    {
        var result = await campaignRuleRepository.FindAllAsync(x=>x.CampaignId==campaignID);
        return result.Select(x=>x.RuleId).ToList();
    }
}
