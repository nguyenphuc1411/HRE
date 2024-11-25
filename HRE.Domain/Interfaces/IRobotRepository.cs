
using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;
public interface IRobotRepository
{
    Task<Robot> Create(Robot robot);

    Task<bool> Update(Robot robot);

    Task<bool> Delete(int id);

    Task<Robot?> GetByID(int id);

    Task<List<Robot>> GetAll();
}
