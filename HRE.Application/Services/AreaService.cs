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

    public async Task<Area?> Create(AreaDTO entity)
    {
        var result = await areaRepository.Create(mapper.Map<Area>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await areaRepository.Delete(id);
    }

    public async Task<List<GetAreaDTO>> GetAll()
    {
        var data = await areaRepository.GetAll();
        var result = data.Select(x=>new GetAreaDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            TotalLocationOfArea = x.Locations.Count()
        }).ToList();

        return result;
    }

    public async Task<GetAreaDTO?> GetById(int id)
    {
        var data = await areaRepository.GetByIDQuery(id);
        if(data==null) return null;
        var result = new GetAreaDTO
        {
            Id = data.Id,
            Name = data.Name,
            Description = data.Description,
            TotalLocationOfArea = data.Locations.Count()
        };
        return result;
    }

    public async Task<bool> Update(int id,AreaDTO entity)
    {
        var entityToUpdate = await areaRepository.GetByID(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await areaRepository.Update(entityToUpdate);
    }
}
