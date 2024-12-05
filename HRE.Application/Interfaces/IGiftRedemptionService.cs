
using HRE.Application.DTOs.GiftRedemption;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IGiftRedemptionService
{
    Task<GiftRedemption?> Create(RedemptionDTO redemptionDTO);
    Task<GiftReturn?> ReturnGift(ReturnDTO returnDTO);
}
