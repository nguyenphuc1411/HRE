using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface ICampaignRepository
{
    Task<Campaign?> Create(Campaign entity);

    Task<bool> Update(Campaign entity);

    Task<bool> Delete(int id);

    Task<Campaign?> GetByID(int id);

    Task<List<Campaign>> GetAll();

    Task BeginTransaction();

    Task CommitTransaction();

    Task RollbackTransaction();

    // ROBOT
    Task<RobotCampaign?> AddRobotToCampaign(RobotCampaign entity);
    Task<bool> RemoveRobotFromCampaign(int campaignID, int robotID);

    // Machine
    Task<MachineCampaign?> AddRMToCampaign(MachineCampaign entity);
    Task<bool> RemoveRMFromCampaign(int campaignID, int machineID);

    // GIFT
    Task<CampaignGiftRule?> AddGiftToCampaign(CampaignGiftRule entity);
    Task<bool> UpdateGiftFromCampaign(CampaignGiftRule entity);
    Task<bool> RemoveGiftFromCampaign(int id);

    Task<CampaignGiftRule?> GetGiftByID(int id);
}
