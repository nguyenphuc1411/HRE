using AutoMapper;
using HRE.Application.DTOs.UserInteraction;
using HRE.Application.Extentions;
using HRE.Application.Interfaces;
using HRE.Domain.Entities;
using HRE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HRE.Application.Services;

public class UserInteractionService : IUserInteractionService
{
    private readonly IBaseRepository<UserInteraction> repository;
    private readonly IBaseRepository<CampaignRule> campaignRuleRepository;
    private readonly IBaseRepository<CampaignGift> campaignGiftRepository;
    private readonly IBaseRepository<QRCode> qrCodeRepository;
    private readonly IMapper mapper;
    private readonly IAuthService authService;
    public UserInteractionService(
        IBaseRepository<UserInteraction> repository,
        IMapper mapper, IAuthService authService,
        IBaseRepository<CampaignRule> campaignRuleRepository,
        IBaseRepository<CampaignGift> campaignGiftRepository,
        IBaseRepository<QRCode> qrCodeRepository)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.authService = authService;
        this.campaignRuleRepository = campaignRuleRepository;
        this.campaignGiftRepository = campaignGiftRepository;
        this.qrCodeRepository = qrCodeRepository;
    }

    public async Task<UserInteraction?> StartInteraction(StartUserInteractionDTO createInteraction)
    {
        int userID = authService.GetUserID();

        var newEntity = mapper.Map<UserInteraction>(createInteraction);
        newEntity.UserId=userID;
        
        await repository.AddAsync(newEntity);
        var result = await repository.SaveChangesAsync();
        return result>0 ? newEntity : null;
    }
    public async Task<UserInteraction?> FinishInteraction(FinishInteractionDTO finishInteraction)
    {
        // Lấy thông tin tương tác từ repository
        var interaction = await repository.GetByIdAsync(finishInteraction.Id);
        if (interaction == null) return null;

        if (finishInteraction.IsSpin)
        {
            // Lấy quy tắc trúng thưởng dựa trên điểm tích lũy
            var giftInRule = await campaignRuleRepository.AsQueryable()
                        .Where(x => x.CampaignId == interaction.CampaignId &&
                                    x.GiftRule.MinPoints <= finishInteraction.PointEarned &&
                                    x.GiftRule.MaxPoints >= finishInteraction.PointEarned)
                        .SelectMany(x => x.GiftRule.GiftInRules)
                        .ToListAsync();

            if (giftInRule == null || !giftInRule.Any()) return null;

            // Lấy danh sách quà đã hết
            var giftIDsOutOfStock = await campaignGiftRepository.AsQueryable()
                                        .Where(x => x.CampaignId == interaction.CampaignId &&
                                                    (x.InitialQuantity - x.WonQuantity) <= 0)
                                        .Select(x => x.GiftId)
                                        .ToListAsync();

            // Lọc danh sách quà còn trong kho
            var availableGifts = giftInRule.Where(x => !giftIDsOutOfStock.Contains(x.GiftId)).ToList();
            if (!availableGifts.Any()) return null;

            // Tính tổng tỷ lệ trúng thưởng
            int totalWinningRate = availableGifts.Sum(x => x.WinningRate);

            // Random số từ 1 đến 100
            int randomNumber = Random.Shared.Next(1, 101);

            if (randomNumber <= totalWinningRate)
            {
                // Tìm phần quà trúng thưởng

                int randomGift = new Random().Next(1, 101); // random cho phần quà
                int cumulativeRate = 0;
                GiftInRule? selectedGift = null;

                foreach (var gift in availableGifts)
                {
                    int normalizedRate = (int)((float)gift.WinningRate / totalWinningRate * 100);

                    cumulativeRate += normalizedRate;

                    if (randomGift <= cumulativeRate)
                    {
                        selectedGift = gift;
                        break;
                    }
                }

                if (selectedGift != null)
                {
                    // Cập nhật thông tin phần quà trúng thưởng
                    var campaignGift = await campaignGiftRepository.AsQueryable()
                                            .FirstOrDefaultAsync(x => x.CampaignId == interaction.CampaignId &&
                                                                      x.GiftId == selectedGift.GiftId);
                    if (campaignGift != null)
                    {
                        campaignGift.WonQuantity++;
                        campaignGiftRepository.Update(campaignGift);
                        await campaignGiftRepository.SaveChangesAsync();
                    }

                    // Cập nhật trạng thái tương tác
                    interaction.IsSpun = true;
                    interaction.EndTime = DateTime.Now;
                    interaction.PointEarned = finishInteraction.PointEarned;
                    interaction.GiftId = selectedGift.GiftId;
                    interaction.IsWon = true;

                    // Tạo mã QRCode

                    var byteQRCode = QRCodeService.GenerateQRCode(selectedGift.GiftId.ToString());
                    var fileName = interaction.Id.ToString()+selectedGift.GiftId.ToString();

                    // Gửi mail cho người dùng trúng thưởng




                    var filePath = await QRCodeService.SaveQRCodeToFile(byteQRCode,fileName);
                    var newQRCode = new QRCode()
                    {
                        InteractionId = interaction.Id,
                        QRCodeURL = filePath
                    };
                    await qrCodeRepository.AddAsync(newQRCode);
                    await qrCodeRepository.SaveChangesAsync();

                    repository.Update(interaction);
                    var result = await repository.SaveChangesAsync();
                    return result>0 ? interaction:null;
                }
            }

            // Không trúng thưởng
            interaction.IsSpun = true;
            interaction.IsWon = false;
            interaction.EndTime = DateTime.Now;
            interaction.PointEarned = finishInteraction.PointEarned;

            repository.Update(interaction);
            await repository.SaveChangesAsync();
            return interaction;
        }
        else
        {
            // Không quay thưởng
            interaction.IsSpun = false;
            interaction.EndTime = DateTime.Now;
            interaction.PointEarned = finishInteraction.PointEarned;

            repository.Update(interaction);
            var result = await repository.SaveChangesAsync();
            return result > 0 ? interaction : null;
        }
    }
}
