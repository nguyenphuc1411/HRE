using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IGiftRepository
{
    Task<Gift?> Create(Gift entity);

    Task<bool> Update(Gift entity);

    Task<bool> Delete(int id);

    Task<Gift?> GetByID(int id);

    Task<List<Gift>> GetAll();
}
