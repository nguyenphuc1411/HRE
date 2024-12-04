using HRE.Application.DTOs.Robot;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRobotService
{
    Task<Robot?> Create(CreateRobotDTO entity);

    Task<GetRobotDTO> GetByID(int id);
    Task<PaginatedModel<GetRobotDTO>> GetAll(QueryModel query);

    Task<bool> Update(UpdateRobotDTO entity);
    Task<bool> Delete(int id);
}
