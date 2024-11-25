using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(255)")]
    public string Fullname { get; set; } = default!;

    [Column(TypeName = "Varchar(100)")]
    public string Username { get; set; } = default!;
    [Column(TypeName = "Varchar(255)")]
    public string Email { get; set; } = default!;
    [Column(TypeName = "NVarchar(max)")]
    public string Password { get; set; } = default!;
    public bool Status { get; set; } = false;
    public DateTime DateAdded { get; set; }

    public int RoleId {  get; set; }
    public Role Role { get; set; } = new();

    public ICollection<UserPoint> UserPoints { get; set; } = new List<UserPoint>();
    public ICollection<SpinHistory> SpinHistories { get; set; } = new List<SpinHistory>();
    public ICollection<RewardRedemption> RewardRedemptions { get; set; }=new List<RewardRedemption>();
    public ICollection<RewardReturnHistory> RewardReturnHistories { get; set; } = new List<RewardReturnHistory>();
    public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
