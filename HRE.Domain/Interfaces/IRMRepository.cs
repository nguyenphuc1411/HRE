using HRE.Domain.Entities;

namespace HRE.Domain.Interfaces;

public interface IRMRepository
{
    Task<RecyclingMachine?> Create(RecyclingMachine entity);

    Task<bool> Update(RecyclingMachine entity);

    Task<bool> Delete(int id);

    Task<RecyclingMachine?> GetByID(int id);

    Task<List<RecyclingMachine>> GetAll();
}
