
using AutoMapper;
using HRE.Application.DTOs.Gift;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class GiftService : IGiftService
{
    private readonly IBaseRepository<Gift> giftRepository;
    private readonly IMapper mapper;

    public GiftService(IBaseRepository<Gift> giftRepository, IMapper mapper)
    {
        this.giftRepository = giftRepository;
        this.mapper = mapper;
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

    public async Task<bool> Update(int id, GiftDTO entity)
    {
        var entityToUpdate = await giftRepository.GetByIdAsync(id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        giftRepository.Update(entityToUpdate);

        return await giftRepository.SaveChangesAsync() > 0;
    }
}
