using AutoMapper;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.DTOs.Robot;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RecyclingMachineService : IRecyclingMachineService
{
    private readonly IBaseRepository<RecyclingMachine> rMRepository;
    private readonly IMapper mapper;
    public RecyclingMachineService(IBaseRepository<RecyclingMachine> rMRepository, IMapper mapper)
    {
        this.rMRepository = rMRepository;
        this.mapper = mapper;
    }

    public async Task<RecyclingMachine?> Create(CreateRMDTO entity)
    {
        var rm = mapper.Map<RecyclingMachine>(entity);
        await rMRepository.AddAsync(rm);
        var result = await rMRepository.SaveChangesAsync();
        return result > 0 ? rm : null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await rMRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        rMRepository.Delete(entityToDelete);
        return await rMRepository.SaveChangesAsync() > 0;
    }

    public async Task<List<GetRMDTO>> GetAll()
    {
        var data = await rMRepository.GetAllAsync();
        return mapper.Map<List<GetRMDTO>>(data);
    }

    public Task<GetRobotDTO> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(UpdateRMDTO entity)
    {
        var entityToUpdate = await rMRepository.GetByIdAsync(entity.Id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        rMRepository.Update(entityToUpdate);

        return await rMRepository.SaveChangesAsync() > 0;
    }
}
