using HRE.Application.DTOs.Robot;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRobotService
{
    Task<Robot> Create(CreateRobotDTO entity);

    Task<GetRobotDTO> GetByID(int id);
    Task<List<GetRobotDTO>> GetAll();

    Task<bool> Update(UpdateRobotDTO entity);
    Task<bool> Delete(int id);
}
