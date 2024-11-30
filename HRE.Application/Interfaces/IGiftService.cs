using HRE.Application.DTOs.Gift;
using HRE.Application.DTOs.Location;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftService
{
    Task<Gift?> Create(GiftDTO entity);
    Task<bool> Update(int id, GiftDTO entity);
    Task<bool> Delete(int id);
}
