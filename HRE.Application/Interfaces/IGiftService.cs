using HRE.Application.DTOs.Gift;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftService
{
    Task<PaginatedModel<GetGiftsDTO>> Get(QueryModel query);
    Task<GetGiftDTO?> GetByID(int id);
    Task<Gift?> Create(GiftDTO entity);
    Task<bool> Update(int id, GiftDTO entity);
    Task<bool> Delete(int id);
}
