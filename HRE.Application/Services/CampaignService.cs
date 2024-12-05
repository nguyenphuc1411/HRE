
using AutoMapper;
using HRE.Application.DTOs.Campaign;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class CampaignService : ICampaignService 
{
    private readonly IBaseRepository<Campaign> campaignRepository;
    private readonly IMapper mapper;
    private readonly IBaseRepository<RobotCampaign> robotCampaignRepository;
    private readonly IBaseRepository<MachineCampaign> machineCampaignRepository;
    public CampaignService(
        IBaseRepository<Campaign> campaignRepository,
        IMapper mapper,
        IBaseRepository<RobotCampaign> robotCampaignRepository,
        IBaseRepository<MachineCampaign> machineCampaignRepository,
        IBaseRepository<CampaignGift> gifiCampainRepository)
    {
        this.campaignRepository = campaignRepository;
        this.mapper = mapper;
        this.robotCampaignRepository = robotCampaignRepository;
        this.machineCampaignRepository = machineCampaignRepository;
    }
    public async Task<PaginatedModel<GetCampaignDTO>> Get(QueryModel query)
    {
        var campaigns = await campaignRepository.AsQueryable()
            .Select(x => new
            {
                x.Id,
                x.CampaignName,
                x.StartDate,
                x.EndDate,
                x.Description,
                x.LocationId,
                UserInteractions = x.UserInteractions.Count(),
                QRCodeCount = x.UserInteractions.Select(u => u.QRCode).Count() // Giả sử có trường QRCodeInteractions trong UserInteractions
            })
            .GroupBy(x => x.Id)
            .Select(group => new GetCampaignDTO
            {
                Id = group.Key,
                CampaignName = group.FirstOrDefault().CampaignName,
                StartDate = group.FirstOrDefault().StartDate,
                EndDate = group.FirstOrDefault().EndDate,
                Description = group.FirstOrDefault().Description,
                LocationId = group.FirstOrDefault().LocationId,
                TotalInteraction = group.Sum(x => x.UserInteractions),  // Tổng số lượt tương tác
                TotalQRCode = group.Sum(x => x.QRCodeCount)           // Tổng số QR code đã tạo
            })
            .ApplyQuery(query, x => x.CampaignName);

        return campaigns;
    }

    public Task<GetCampaignDetailDTO> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Campaign?> Create(CampaignDTO entity)
    {
        var campaign = mapper.Map<Campaign>(entity);
        await campaignRepository.AddAsync(campaign);
        var result = await campaignRepository.SaveChangesAsync();
        return result>0?campaign:null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await campaignRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        campaignRepository.Delete(entityToDelete);
        return await campaignRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(int id, CampaignDTO entity)
    {
        var entityToUpdate = await campaignRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        campaignRepository.Update(entityToUpdate);

        return await campaignRepository.SaveChangesAsync() > 0;
    }


    // ROBOT
    public async Task<bool> AddRobotsToCampaign(int id, List<int> robotIDs)
    {
        await robotCampaignRepository.BeginTransactionAsync();
        try
        {
            var listRobotCampaigns = new List<RobotCampaign>();
            foreach (var item in robotIDs)
            {
                listRobotCampaigns.Add(new RobotCampaign
                {
                    RobotId = item,
                    CampaignId = id
                });             
            }
            await robotCampaignRepository.AddRangeAsync(listRobotCampaigns);
            var result = await robotCampaignRepository.SaveChangesAsync();
            if (result == listRobotCampaigns.Count())
            {
                await robotCampaignRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await robotCampaignRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex) 
        { 
            await robotCampaignRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> RemoveRobotsFromCampaign(int id, List<int> robotIDs)
    {
        await robotCampaignRepository.BeginTransactionAsync();
        try
        {
            var listRobotCampaigns = new List<RobotCampaign>();
            foreach (var item in robotIDs)
            {
                listRobotCampaigns.Add(new RobotCampaign
                {
                    RobotId = item,
                    CampaignId = id
                });
            }
            robotCampaignRepository.DeleteRange(listRobotCampaigns);
            var result = await robotCampaignRepository.SaveChangesAsync();
            if (result == listRobotCampaigns.Count())
            {
                await robotCampaignRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await robotCampaignRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await robotCampaignRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }

    // Machine
    public async Task<bool> AddRMsToCampaign(int id, List<int> machineIDs)
    {
        await machineCampaignRepository.BeginTransactionAsync();
        try
        {
            var listMachineCampaigns = new List<MachineCampaign>();
            foreach (var item in machineIDs)
            {
                listMachineCampaigns.Add(new MachineCampaign
                {
                    MachineId = item,
                    CampaignId = id
                });
            }
            await machineCampaignRepository.AddRangeAsync(listMachineCampaigns);
            var result = await machineCampaignRepository.SaveChangesAsync();
            if (result == listMachineCampaigns.Count())
            {
                await machineCampaignRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await machineCampaignRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await machineCampaignRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> RemoveRMsFromCampaign(int id, List<int> machineIDs)
    {
        await machineCampaignRepository.BeginTransactionAsync();
        try
        {
            var listMachineCampaigns = new List<MachineCampaign>();
            foreach (var item in machineIDs)
            {
                listMachineCampaigns.Add(new MachineCampaign
                {
                    MachineId = item,
                    CampaignId = id
                });
            }
            machineCampaignRepository.DeleteRange(listMachineCampaigns);
            var result = await machineCampaignRepository.SaveChangesAsync();
            if (result == listMachineCampaigns.Count())
            {
                await machineCampaignRepository.CommitTransactionAsync();
                return true;
            }
            else
            {
                await machineCampaignRepository.RollbackTransactionAsync();
                return false;
            }
        }
        catch (Exception ex)
        {
            await machineCampaignRepository.RollbackTransactionAsync();
            throw new Exception(ex.Message);
        }
    }
}

