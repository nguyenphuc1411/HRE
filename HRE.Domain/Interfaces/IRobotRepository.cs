
using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;
public interface IRobotRepository
{
    Task<Robot?> Create(Robot entity);

    Task<bool> Update(Robot entity);

    Task<bool> Delete(int id);

    Task<Robot?> GetByID(int id);

    Task<List<Robot>> GetAll();
}
