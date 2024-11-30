
using AutoMapper;
using HRE.Application.DTOs.Location;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class LocationService : ILocationService
{
    private readonly ILocationRepository locationRepository;
    private readonly IMapper mapper;
    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        this.locationRepository = locationRepository;
        this.mapper = mapper;
    }

    public async Task<Location?> Create(LocationDTO entity)
    {
        var result = await locationRepository.Create(mapper.Map<Location>(entity));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await locationRepository.Delete(id);
    }

    public async Task<bool> Update(int id,LocationDTO entity)
    {
        var entityToUpdate = await locationRepository.GetByID(id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        return await locationRepository.Update(entityToUpdate);
    }
}
