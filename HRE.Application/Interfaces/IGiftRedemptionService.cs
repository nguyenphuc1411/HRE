
using HRE.Application.DTOs.GiftRedemption;
using HRE.Application.Models;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftRedemptionService
{
    Task<GiftRedemption?> Create(RedemptionDTO redemptionDTO);
    Task<GiftReturn?> ReturnGift(ReturnDTO returnDTO);

    Task<PaginatedModel<GiftRedemption>> GetHistoryRedemption(QueryModel query);

    Task<PaginatedModel<GiftReturn>> GetHistoryReturn(QueryModel query);
}
