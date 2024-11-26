using HRE.Application.DTOs.RecyclingMachine;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IRecyclingMachineService
{
    Task<RecyclingMachine> Create(CreateRMDTO entity);
    //Task<GetRobotDTO> GetByID(int id);
    Task<List<RecyclingMachine>> GetAll();

    Task<bool> Update(UpdateRMDTO entity);
    Task<bool> Delete(int id);
}
