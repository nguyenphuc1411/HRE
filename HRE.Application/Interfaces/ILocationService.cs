
using HRE.Application.DTOs.Location;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface ILocationService
{
    Task<Location> Create(LocationDTO entity);
    Task<bool> Update(int id,LocationDTO entity);
    Task<bool> Delete(int id);

}
