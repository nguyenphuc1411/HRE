using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRecyclingMachineService
{
    Task<RecyclingMachine?> Create(CreateRMDTO entity);
    //Task<GetRobotDTO> GetByID(int id);
    Task<PaginatedModel<GetRMDTO>> GetAll(QueryModel query);

    Task<bool> Update(UpdateRMDTO entity);
    Task<bool> Delete(int id);
}
