
using AutoMapper;
using HRE.Application.DTOs.Gift;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class GiftService : IGiftService
{
    private readonly IGiftRepository giftRepository;
    private readonly IMapper mapper;

    public GiftService(IGiftRepository giftRepository, IMapper mapper)
    {
        this.giftRepository = giftRepository;
        this.mapper = mapper;
    }

    public async Task<Gift> Create(GiftDTO entity)
    {
        var result = await giftRepository.Create(mapper.Map<Gift>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await giftRepository.Delete(id);
    }

    public async Task<bool> Update(int id, GiftDTO entity)
    {
        var entityToUpdate = await giftRepository.GetByID(id);
        if (entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await giftRepository.Update(entityToUpdate);
    }
}
