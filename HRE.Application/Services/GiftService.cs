
using AutoMapper;
using HRE.Application.DTOs.Gift;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class GiftService : IGiftService
{
    private readonly IBaseRepository<Gift> giftRepository;
    private readonly IBaseRepository<QRCode> qrCodeRepository;
    private readonly IMapper mapper;

    public GiftService(IBaseRepository<Gift> giftRepository, IMapper mapper, IBaseRepository<QRCode> qrCodeRepository)
    {
        this.giftRepository = giftRepository;
        this.mapper = mapper;
        this.qrCodeRepository = qrCodeRepository;
    }

    public async Task<Gift?> Create(GiftDTO entity)
    {
        var gift = mapper.Map<Gift>(entity);
        await giftRepository.AddAsync(gift);
        var result = await giftRepository.SaveChangesAsync();
        return result>0 ? gift : null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await giftRepository.GetByIdAsync(id);
        if(entityToDelete == null) return false;
        giftRepository.Delete(entityToDelete);
        return await giftRepository.SaveChangesAsync()>0;
    }

    public async Task<PaginatedModel<GetGiftsDTO>> Get(QueryModel query)
    {
        var data = await giftRepository.AsQueryable()
            .SelectMany(x => x.CampaignGifts) 
            .GroupBy(x => x.GiftId)  // Nhóm theo GiftId
            .Select(group => new GetGiftsDTO
            {
                Id = group.Key,  // GiftId là khóa nhóm
                GiftName = group.FirstOrDefault().Gift.GiftName,
                ImageUrl = group.FirstOrDefault().Gift.ImageUrl,
                TotalGivens = group.Sum(x => x.QuantityGiven) 
            }).ApplyQuery(query,x=>x.GiftName);
        return data;
    }

    public async Task<GetGiftDTO?> GetByID(int id)
    {
        // Lấy thông tin quà tặng từ bảng Gift (hoặc bảng tương tự)
        var gift = await giftRepository.AsQueryable()
            .Where(x => x.Id == id)
            .Select(x => new GetGiftDTO
            {
                Id = x.Id,
                GiftName = x.GiftName,
                ImageUrl = x.ImageUrl,
                TotalGivens = x.CampaignGifts.Sum(cg => cg.QuantityGiven),  
                                                                     
                TotalExpired = 0  
            })
            .FirstOrDefaultAsync();

        if (gift == null)
        {
            return null;  
        }

        var totalExpired = await qrCodeRepository.AsQueryable()
            .Where(qr => qr.UserInteraction.GiftId == id && qr.ExpirationDate < DateTime.UtcNow && !qr.IsUsed)
            .CountAsync();

        gift.TotalExpired = totalExpired;
        return gift;
    }

    public async Task<bool> Update(int id, GiftDTO entity)
    {
        var entityToUpdate = await giftRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        giftRepository.Update(entityToUpdate);

        return await giftRepository.SaveChangesAsync() > 0;
    }
}
