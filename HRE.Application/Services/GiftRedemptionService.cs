using AutoMapper;
using HRE.Application.DTOs.GiftRedemption;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class GiftRedemptionService : IGiftRedemptionService
{
    private readonly IBaseRepository<GiftRedemption> repository;
    private readonly IBaseRepository<CampaignGift> campaignGiftRepository;
    private readonly IBaseRepository<GiftReturn> returnRepository;
    private readonly IMapper mapper;
    private readonly IAuthService authService;
    public GiftRedemptionService(IBaseRepository<GiftRedemption> repository, IMapper mapper, IBaseRepository<CampaignGift> campaignGiftRepository, IAuthService authService, IBaseRepository<GiftReturn> returnRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.campaignGiftRepository = campaignGiftRepository;
        this.authService = authService;
        this.returnRepository = returnRepository;
    }

    public async Task<GiftRedemption?> Create(RedemptionDTO redemptionDTO)
    {
        var newEntity = mapper.Map<GiftRedemption>(redemptionDTO);
        int userID = authService.GetUserID();
        await repository.AddAsync(newEntity);
        var result = await repository.SaveChangesAsync();
        if (result > 0)
        {
            var interaction = await repository.AsQueryable().Where(x => x.QRCodeId == redemptionDTO.QRCodeId)
                .Select(x => x.QRCode.UserInteraction).FirstOrDefaultAsync();
            if(interaction != null)
            {
                var campaignGift = await campaignGiftRepository.FindAsync(x => x.CampaignId == interaction.CampaignId & x.GiftId == interaction.GiftId);
                if (campaignGift != null)
                {
                    campaignGift.QuantityGiven++;
                    campaignGiftRepository.Update(campaignGift);
                    await campaignGiftRepository.SaveChangesAsync();
                }
            }
            return newEntity;
        }
        return null;
    }

    public async Task<PaginatedModel<GiftRedemption>> GetHistoryRedemption(QueryModel query)
    {
        return await repository.AsQueryable().ApplyQuery(query);
    }

    public async Task<PaginatedModel<GiftReturn>> GetHistoryReturn(QueryModel query)
    {
        return await returnRepository.AsQueryable().ApplyQuery(query);
    }

    public async Task<GiftReturn?> ReturnGift(ReturnDTO returnDTO)
    {
        int userID = authService.GetUserID();
        var newReturn = new GiftReturn()
        {
            RedemptionId = returnDTO.RedemptionId,
            PGStaffId = userID,
            Reason = returnDTO.Reason
        };

        await returnRepository.AddAsync(newReturn);
        var result = await returnRepository.SaveChangesAsync();
        if (result > 0)
        {
            // cập nhật trạng thái ở redemption
            var redemptipon = await repository.GetByIdAsync(returnDTO.RedemptionId);
            if (redemptipon!=null)
            {
                redemptipon.Status = "Returned";
                repository.Update(redemptipon);
                await repository.SaveChangesAsync();
            }
        }
        return null;
    }
}
