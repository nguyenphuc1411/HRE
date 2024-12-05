using AutoMapper;
using AutoMapper.QueryableExtensions;
using HRE.Application.DTOs.RecyclingMachine;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Application.Models;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class RecyclingMachineService : IRecyclingMachineService
{
    private readonly IBaseRepository<RecyclingMachine> rMRepository;
    private readonly IBaseRepository<QRCode> qrRepository;
    private readonly IMapper mapper;
    public RecyclingMachineService(IBaseRepository<RecyclingMachine> rMRepository, 
        IMapper mapper, IBaseRepository<QRCode> qrRepository)
    {
        this.rMRepository = rMRepository;
        this.mapper = mapper;
        this.qrRepository = qrRepository;
    }

    public async Task<RecyclingMachine?> Create(CreateRMDTO entity)
    {
        var rm = mapper.Map<RecyclingMachine>(entity);
        await rMRepository.AddAsync(rm);
        var result = await rMRepository.SaveChangesAsync();
        return result > 0 ? rm : null;
    }

    public async Task<bool> Delete(int id)
    {
        var entityToDelete = await rMRepository.GetByIdAsync(id);
        if (entityToDelete == null) return false;
        rMRepository.Delete(entityToDelete);
        return await rMRepository.SaveChangesAsync() > 0;
    }

    public async Task<PaginatedModel<GetRMDTO>> GetAll(QueryModel query)
    {
        var data = await rMRepository.AsQueryable()
            .ProjectTo<GetRMDTO>(mapper.ConfigurationProvider)
            .ApplyQuery(query,x=>x.MachineCode);
        return data;
    }
    public async Task<bool> Update(UpdateRMDTO entity)
    {
        var entityToUpdate = await rMRepository.GetByIdAsync(entity.Id);
        if (entityToUpdate == null) return false;

        mapper.Map(entity, entityToUpdate);
        rMRepository.Update(entityToUpdate);

        return await rMRepository.SaveChangesAsync() > 0;
    }

    public async Task<GetRMDetailDTO?> GetByID(int id)
    {
        // Lấy thông tin máy tái chế theo ID
        var machine = await rMRepository.AsQueryable()
            .Where(x => x.Id == id)
            .Include(x => x.Location)  // Lấy thông tin vị trí máy tái chế
            .Include(x => x.MachineCampaigns).ThenInclude(x => x.Campaign)  // Lấy thông tin chiến dịch liên quan
            .Include(x => x.UserInteractions).ThenInclude(x => x.QRCode)  // Lấy thông tin QRCode liên quan
            .FirstOrDefaultAsync();

        if (machine == null)
        {
            return null;  // Nếu không tìm thấy máy tái chế
        }

        // Tính toán các thông tin liên quan đến tương tác và quà tặng
        var interactions = machine.UserInteractions.Where(x => x.EndTime != null).ToList();

        // Tính tổng số quà đã phát
        var totalGivens = interactions.Sum(x => x.PointEarned ?? 0);

        // Tính tổng số quà hết hạn (QR chưa sử dụng và đã hết hạn)
        var totalExpired = await qrRepository.AsQueryable()
            .Where(qr => qr.ExpirationDate < DateTime.UtcNow && qr.IsUsed == false && qr.UserInteraction.MachineId == id)
            .CountAsync();

        // Ánh xạ dữ liệu từ RecyclingMachine và UserInteraction sang GetRMDetailDTO
        var dto = new GetRMDetailDTO
        {
            MachineCode = machine.MachineCode,
            Status = machine.Status,
            BinStatus = machine.BinStatus,
            AccessCount = machine.AccessCount,
            LocationId = machine.LocationId,
            Location = machine.Location?.Name,  // Lấy tên vị trí máy tái chế
            TotalGivens = totalGivens,
            TotalExpired = totalExpired,
            Campaigns = machine.MachineCampaigns.Select(campaign => new CampaignDTOForRM
            {
                CampaignId = campaign.CampaignId,
                CampaignName = campaign.Campaign.CampaignName,
                CampaignStartDate = campaign.Campaign.StartDate,
                CampaignEndDate = campaign.Campaign.EndDate,
            }).ToList(),
            Interactions = interactions.Select(interaction => new UserInteractionDTOForRM
            {
                UserId = interaction.UserId,
                InteractionStartTime = interaction.StartTime,
                InteractionEndTime = interaction.EndTime,
                PointsEarned = interaction.PointEarned ?? 0,
                Result = interaction.IsWon == true ? "Trúng thưởng" : "Không trúng thưởng",
                GiftReceived = interaction.Gift?.GiftName,
                RewardDate = interaction.SpunDate,
                QRCodeStatus = interaction.QRCode?.IsUsed == true ? "Đã sử dụng" : "Chưa sử dụng",
                QRCodeUsedDate = interaction.QRCode?.UsedDate,
                PGStaffId = interaction.QRCode?.GiftRedemption?.PGStaffId  // Lấy thông tin PGStaffId từ GiftRedemption
            }).ToList()
        };

        return dto;
    }
}
