using AutoMapper;
using HRE.Application.DTOs.Area;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class AreaService:IAreaService
{
    private readonly IAreaRepository areaRepository;
    private readonly IMapper mapper;
    public AreaService(IAreaRepository areaRepository, IMapper mapper)
    {
        this.areaRepository = areaRepository;
        this.mapper = mapper;
    }

    public async Task<Area> Create(AreaDTO entity)
    {
        var result = await areaRepository.Create(mapper.Map<Area>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await areaRepository.Delete(id);
    }

    public async Task<bool> Update(int id,AreaDTO entity)
    {
        var entityToUpdate = await areaRepository.GetByID(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await areaRepository.Update(entityToUpdate);
    }
}
