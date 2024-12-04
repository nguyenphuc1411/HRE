
using HRE.Application.DTOs.Area;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IAreaService
{
    Task<Area?> Create(AreaDTO entity);
    Task<bool> Update(int id,AreaDTO entity);
    Task<bool> Delete(int id);
    Task<GetAreaDTO?> GetById(int id);

    Task<PaginatedModel<GetAreaDTO>> GetAll(QueryModel query);
}
