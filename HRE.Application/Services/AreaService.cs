using AutoMapper;
using HRE.Application.DTOs.Area;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class AreaService:IAreaService
{
    private readonly IBaseRepository<Area> areaRepository;
    private readonly IMapper mapper;
    public AreaService(IBaseRepository<Area> areaRepository,IMapper mapper)
    {
        this.mapper = mapper;
        this.areaRepository = areaRepository;
    }

    public async Task<Area?> Create(AreaDTO entity)
    {
        var area = mapper.Map<Area>(entity);
        await areaRepository.AddAsync(area);
        var result = await areaRepository.SaveChangesAsync();
        if(result>0) return area;
        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await areaRepository.GetByIdAsync(id);
        if(entityToDelete==null) return false;

        areaRepository.Delete(entityToDelete);

        return await areaRepository.SaveChangesAsync()>0;
    }

    public async Task<PaginatedModel<GetAreaDTO>> GetAll(QueryModel query)
    {
        var result = await areaRepository.AsQueryable().Select(x => new GetAreaDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            TotalLocationOfArea = x.Locations.Count()
        }).ApplyQuery(query,a=>a.Name);
        return result;
    }

    public async Task<GetAreaDTO?> GetById(int id)
    {
        return await areaRepository.AsQueryable().Select(x=>new GetAreaDTO
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            TotalLocationOfArea = x.Locations.Count()
        }).FirstOrDefaultAsync(a=>a.Id==id);
    }

    public async Task<bool> Update(int id,AreaDTO entity)
    {
        var entityToUpdate = await areaRepository.GetByIdAsync(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        areaRepository.Update(entityToUpdate);
        return await areaRepository.SaveChangesAsync() > 0;
    }
}
