
using HRE.Application.DTOs.Campaign;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface ICampaignService
{
    Task<Campaign?> Create(CampaignDTO entity);
    Task<bool> Update(int id, CampaignDTO entity);
    Task<bool> Delete(int id);
    Task<PaginatedModel<GetCampaignDTO>> Get(QueryModel query);
    Task<GetCampaignDetailDTO?> GetByID(int id);

    // Robot
    Task<bool> AddRobotsToCampaign(int id,List<int> robotIDs);
    Task<bool> RemoveRobotsFromCampaign(int id, List<int> robotIDs);

    // Machine
    Task<bool> AddRMsToCampaign(int id, List<int> machineIDs);
    Task<bool> RemoveRMsFromCampaign(int id, List<int> machineIDs);
}
