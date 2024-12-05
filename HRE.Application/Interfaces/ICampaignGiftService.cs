using HRE.Application.DTOs.Campaign;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface ICampaignGiftService
{
    Task<IEnumerable<CampaignGift>> GetCampaignGifts(int campaignID);
    Task<CampaignGift?> Create(CampaignGiftDTO entity);
    Task<bool> Update(int id, CampaignGiftDTO entity);
    Task<bool> Delete(int id);
}
