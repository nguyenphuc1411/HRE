
using AutoMapper;
using HRE.Application.DTOs.Campaign;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class CampaignGiftService: ICampaignGiftService
{
    private readonly IBaseRepository<CampaignGift> campaignGiftRepository;
    private readonly IMapper mapper;
    public CampaignGiftService(IBaseRepository<CampaignGift> campaignGiftRepository, IMapper mapper)
    {
        this.campaignGiftRepository = campaignGiftRepository;
        this.mapper = mapper;
    }

    public async Task<CampaignGift?> Create(CampaignGiftDTO entity)
    {
        var newEntity = mapper.Map<CampaignGift>(entity);

        await campaignGiftRepository.AddAsync(newEntity);

        var result = await campaignGiftRepository.SaveChangesAsync();
        return result > 0 ? newEntity : null;
    }
    public async Task<bool> Update(int id, CampaignGiftDTO entity)
    {
        var entityToUpdate = await campaignGiftRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        campaignGiftRepository.Update(entityToUpdate);

        return await campaignGiftRepository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await campaignGiftRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        campaignGiftRepository.Delete(entityToDelete);
        return await campaignGiftRepository.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<CampaignGift>> GetCampaignGifts(int campaignID)
    {
        return await campaignGiftRepository.FindAllAsync(x => x.CampaignId == campaignID);
    }
}
