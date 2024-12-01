using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IAreaRepository
{
    Task<Area?> Create(Area entity);

    Task<bool> Update(Area entity);

    Task<bool> Delete(int id);

    Task<Area?> GetByIDQuery(int id);
    Task<Area?> GetByID(int id);

    Task<List<Area>> GetAll();
}
