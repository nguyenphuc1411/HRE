using AutoMapper;
using HRE.Application.DTOs.Robot;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;

namespace HRE.Application.Services;

public class RobotService:IRobotService
{
    private readonly IRobotRepository robotRepository;
    private readonly IMapper mapper;
    public RobotService(IRobotRepository robotRepository, IMapper mapper)
    {
        this.robotRepository = robotRepository;
        this.mapper = mapper;
    }

    public async Task<Robot> Create(CreateRobotDTO robot)
    {
        var result = await robotRepository.Create(mapper.Map<Robot>(robot));
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await robotRepository.Delete(id);
    }

    public async Task<List<GetRobotDTO>> GetAll()
    {
        var result = await robotRepository.GetAll();
        return mapper.Map<List<GetRobotDTO>>(result);
    }

    public async Task<GetRobotDTO> GetByID(int id)
    {
        var robot = await robotRepository.GetByID(id);

        return mapper.Map<GetRobotDTO>(robot);
    }

    public async Task<bool> Update(UpdateRobotDTO robot)
    {
        return await robotRepository.Update(mapper.Map<Robot>(robot));
    }
}
