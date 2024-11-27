using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface ILocationRepository
{
    Task<Location> Create(Location entity);

    Task<bool> Update(Location entity);

    Task<bool> Delete(int id);

    Task<Location?> GetByID(int id);

    Task<List<Location>> GetAll();
}
