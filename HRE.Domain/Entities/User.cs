using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(255)")]
    public string Username { get; set; } = default!;
    [Column(TypeName = "Varchar(255)")]
    public string Email { get; set; } = default!;
    [Column(TypeName = "NVarchar(255)")]
    public string Fullname { get; set; } = default!;
    [Column(TypeName = "Varchar(max)")]
    public string PasswordHash { get; set; } = default!;

    public ICollection<CampaignSelection> CampaignSelections { get; set; } = new List<CampaignSelection>();
    public ICollection<AccumulationPoint> AccumulationPoints { get; set; } = new List<AccumulationPoint>();
    public ICollection<SpinHistory> SpinHistories { get; set; } = new List<SpinHistory>();
    public ICollection<UserRole> UserRoles { get; set; }= new List<UserRole>();
    public ICollection<RewardRedemption> RewardRedemptions { get; set; }=new List<RewardRedemption>();
    public ICollection<RedemptionHistory> RedemptionHistories { get; set; } = new List<RedemptionHistory>();
    public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
