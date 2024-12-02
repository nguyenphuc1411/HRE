
using HRE.Application.DTOs.Campaign;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface ICampaignService
{
    Task<Campaign?> Create(CampaignDTO entity);
    Task<bool> Update(int id, CampaignDTO entity);
    Task<bool> Delete(int id);


    // Robot
    Task<bool> AddRobotsToCampaign(int id,List<int> robotIDs);
    Task<bool> RemoveRobotsFromCampaign(int id, List<int> robotIDs);

    // Machine
    Task<bool> AddRMsToCampaign(int id, List<int> machineIDs);
    Task<bool> RemoveRMsFromCampaign(int id, List<int> machineIDs);

    // GIFT
    Task<CampaignGiftRule?> AddGiftToCampaign(int campaignID, CampaignGiftRuleDTO entity);
    Task<bool> UpdateGiftInCampaign(int id,CampaignGiftRuleDTO entity);

    Task<bool> RemoveGiftInCampaign(int id);

    // VẬN HÀNH CHIẾN DỊCH

    Task<Reward?> Spin(int id);
}
