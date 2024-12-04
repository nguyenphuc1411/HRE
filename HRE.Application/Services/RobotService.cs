using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRE.Application.DTOs.Robot;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RobotService:IRobotService
{
    private readonly IBaseRepository<Robot> robotRepository;
    private readonly IMapper mapper;

    public RobotService(IBaseRepository<Robot> robotRepository, IMapper mapper)
    {
        this.robotRepository = robotRepository;
        this.mapper = mapper;
    }

    public async Task<Robot?> Create(CreateRobotDTO entity)
    {
        var robot = mapper.Map<Robot>(entity);
        await robotRepository.AddAsync(robot);
        var result = await robotRepository.SaveChangesAsync();
        if (result > 0) return robot;
        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await robotRepository.GetByIdAsync(id);
        if(entityToDelete == null) return false;
        robotRepository.Delete(entityToDelete);

        return await robotRepository.SaveChangesAsync()>0;
    }

    public async Task<PaginatedModel<GetRobotDTO>> GetAll(QueryModel query)
    {
        return await robotRepository.AsQueryable()
            .ProjectTo<GetRobotDTO>(mapper.ConfigurationProvider)
            .ApplyQuery(query,x=>x.RobotCode);
    }

    public async Task<GetRobotDTO> GetByID(int id)
    {
        var robot = await robotRepository.GetByIdAsync(id);

        return mapper.Map<GetRobotDTO>(robot);
    }

    public async Task<bool> Update(UpdateRobotDTO entity)
    {
        var entityToUpdate = await robotRepository.GetByIdAsync(entity.Id);
        if(entityToUpdate == null) return false;
        mapper.Map(entity, entityToUpdate);
        robotRepository.Update(entityToUpdate);
        return await robotRepository.SaveChangesAsync()>0;
    }
}
