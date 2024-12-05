
using HRE.Application.DTOs.CampaignRule;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface ICampaignRuleService
{
    Task<CampaignRule?> Create(CampaignRuleDTO entity);

    Task<IEnumerable<CampaignRule>?> CreateMultiple(IEnumerable<CampaignRuleDTO> entities);

    Task<IEnumerable<CampaignRuleDTO>> GetAllCampaignRule();

    Task<IEnumerable<int>> GetRulesOfCampaign(int campaignID);

    Task<bool> Delete(CampaignRuleDTO entity);
    Task<bool> DeleteMultiple(IEnumerable<CampaignRuleDTO> entities);
}
