
using AutoMapper;
using HRE.Application.DTOs.Campaign;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository campaignRepository;
    private readonly IMapper mapper;
    public CampaignService(ICampaignRepository campaignRepository, IMapper mapper)
    {
        this.campaignRepository = campaignRepository;
        this.mapper = mapper;
    }

    public async Task<Campaign?> Create(CampaignDTO entity)
    {
        var newEntity = mapper.Map<Campaign>(entity);
        return await campaignRepository.Create(newEntity);
    }

    public async Task<bool> Delete(int id)
    {
        return await campaignRepository.Delete(id);
    }

    public async Task<bool> Update(int id, CampaignDTO entity)
    {
        var entityToUpdate = await campaignRepository.GetByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await campaignRepository.Update(entityToUpdate);
    }


    // ROBOT
    public async Task<bool> AddRobotsToCampaign(int id, List<int> robotIDs)
    {
        await campaignRepository.BeginTransaction();
        try
        {
            foreach (var item in robotIDs)
            {
                var newEntity = new RobotCampaign
                {
                    RobotId = item,
                    CampaignId = id
                };
                var result = await campaignRepository.AddRobotToCampaign(newEntity);
                if (result == null)
                {
                    await campaignRepository.RollbackTransaction();
                    return false;
                }
            }
            await campaignRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex) 
        { 
            await campaignRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> RemoveRobotsFromCampaign(int id, List<int> robotIDs)
    {
        await campaignRepository.BeginTransaction();
        try
        {
            foreach (var item in robotIDs)
            {              
                bool result = await campaignRepository.RemoveRobotFromCampaign(id,item);
                if (!result)
                {
                    await campaignRepository.RollbackTransaction();
                    return false;
                }
            }
            await campaignRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            await campaignRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }

    // Machine
    public async Task<bool> AddRMsToCampaign(int id, List<int> machineIDs)
    {
        await campaignRepository.BeginTransaction();
        try
        {
            foreach (var item in machineIDs)
            {
                var newEntity = new MachineCampaign
                {
                    MachineId = item,
                    CampaignId = id
                };
                var result = await campaignRepository.AddRMToCampaign(newEntity);
                if (result == null)
                {
                    await campaignRepository.RollbackTransaction();
                    return false;
                }
            }
            await campaignRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            await campaignRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> RemoveRMsFromCampaign(int id, List<int> machineIDs)
    {
        await campaignRepository.BeginTransaction();
        try
        {
            foreach (var item in machineIDs)
            {
                bool result = await campaignRepository.RemoveRMFromCampaign(id, item);
                if (!result)
                {
                    await campaignRepository.RollbackTransaction();
                    return false;
                }
            }
            await campaignRepository.CommitTransaction();
            return true;
        }
        catch (Exception ex)
        {
            await campaignRepository.RollbackTransaction();
            throw new Exception(ex.Message);
        }
    }

    // GIFT
    public async Task<CampaignGiftRule?> AddGiftToCampaign(int campaignID, CampaignGiftRuleDTO entity)
    {
        var newEntity = mapper.Map<CampaignGiftRule>(entity);
        newEntity.CampaignId=campaignID;
        return await campaignRepository.AddGiftToCampaign(newEntity);
    }
    public async Task<bool> UpdateGiftInCampaign(int id, CampaignGiftRuleDTO entity)
    {
        var entityToUpdate = await campaignRepository.GetGiftByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await campaignRepository.UpdateGiftFromCampaign(entityToUpdate);
    }

    public async Task<bool> RemoveGiftInCampaign(int id)
    {
        return await campaignRepository.RemoveGiftFromCampaign(id);
    }

}
