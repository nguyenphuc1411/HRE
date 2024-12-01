using AutoMapper;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.DTOs.Robot;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RecyclingMachineService : IRecyclingMachineService
{
    private readonly IRMRepository rMRepository;
    private readonly IMapper mapper;
    public RecyclingMachineService(IRMRepository rMRepository, IMapper mapper)
    {
        this.rMRepository = rMRepository;
        this.mapper = mapper;
    }

    public async Task<RecyclingMachine?> Create(CreateRMDTO entity)
    {
        return await rMRepository.Create(mapper.Map<RecyclingMachine>(entity));
    }

    public async Task<bool> Delete(int id)
    {
        return await rMRepository.Delete(id);
    }

    public async Task<List<GetRMDTO>> GetAll()
    {
        return mapper.Map<List<GetRMDTO>>(await rMRepository.GetAll());
    }

    public Task<GetRobotDTO> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(UpdateRMDTO entity)
    {
        return await rMRepository.Update(mapper.Map<RecyclingMachine>(entity));
    }
}
