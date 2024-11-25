using HRE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRE.Infrastructure.Persistence
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        #region DBSET
        public required DbSet<User> Users { get; set; }
        public required DbSet<UserToken> UserTokens { get; set; }
        public required DbSet<Role> Roles { get; set; }
        public required DbSet<PermissionGroup> PermissionGroups { get; set; }
        public required DbSet<Permission> Permissions { get; set; }
        public required DbSet<RolePermission> RolePermissions { get; set; }
        public required DbSet<UserRole> UserRoles { get; set; }
        public required DbSet<Robot> Robots { get; set; }
        public required DbSet<RecyclingMachine> RecyclingMachines { get; set; }
        public required DbSet<RobotCampaign> RobotCampaigns { get; set; }
        public required DbSet<MachineCampaign> MachineCampaigns { get; set; }
        public required DbSet<Campaign> Campaigns { get; set; }
        public required DbSet<CampaignSelection> CampaignSelections { get; set; }
        public required DbSet<AccumulationPoint> AccumulationPoints { get; set; }
        public required DbSet<SpinHistory> SpinHistories { get; set; }
        public required DbSet<Reward> Rewards { get; set; }
        public required DbSet<RewardRedemption> RewardRedemptions { get; set; }
        public required DbSet<RedemptionHistory> RedemptionHistories { get; set; }
        public required DbSet<Gift> Gifts { get; set; }
        public required DbSet<CampaignGift> CampaignGifts { get; set; }
        public required DbSet<RewardRule> RewardRules { get; set; }
        public required DbSet<GiftRewardRule> GiftRewardRules { get; set; }
        public required DbSet<CampaignRewardRule> CampaignRewardRules { get; set; }
        public required DbSet<Location> Locations { get; set; }
        public required DbSet<Area> Areas { get; set; }
        public required DbSet<Province> Provinces { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Thiet lap khoa ngoai

            // User
            modelBuilder.Entity<User>(options =>
            {
                options.HasMany(x => x.CampaignSelections).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                options.HasMany(x => x.AccumulationPoints).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                options.HasMany(x => x.SpinHistories).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                options.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                options.HasMany(x => x.RewardRedemptions).WithOne(x => x.User).HasForeignKey(x => x.RedeemedBy);
                options.HasMany(x => x.RedemptionHistories).WithOne(x => x.User).HasForeignKey(x => x.PerformBy);
                options.HasMany(x => x.UserTokens).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            });

            // Robot Machine
            modelBuilder.Entity<Robot>().HasMany(x => x.RobotCampaigns).WithOne(x => x.Robot).HasForeignKey(x => x.RobotId);
            modelBuilder.Entity<RecyclingMachine>().HasMany(x => x.MachineCampaigns).WithOne(x => x.Machine).HasForeignKey(x => x.MachineId);

            // Role
            modelBuilder.Entity<Role>(options =>
            {
                options.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
                options.HasMany(x => x.RolePermissions).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            });

            //Permission Group
            modelBuilder.Entity<PermissionGroup>()
            .HasMany(x => x.Permissions).WithOne(x => x.PermissionGroup).HasForeignKey(x => x.GroupId);

            //Permission
            modelBuilder.Entity<Permission>()
            .HasMany(x => x.RolePermissions).WithOne(x => x.Permission).HasForeignKey(x => x.PermissionId);

            // Reward
            modelBuilder.Entity<Reward>(options =>
            {
                options.HasOne(x => x.SpinHistory).WithOne(x => x.Reward).HasForeignKey<SpinHistory>(x => x.RewardId);
                options.HasOne(x => x.RewardRedemption).WithOne(x => x.Reward).HasForeignKey<RewardRedemption>(x => x.RewardId);
            });


            // Reward Redemption
            modelBuilder.Entity<RewardRedemption>(options =>
            {
                options.HasMany(x => x.RedemptionHistories).WithOne(x => x.RewardRedemption).HasForeignKey(x => x.RedemptionID);
            });

            // Campaign
            modelBuilder.Entity<Campaign>(options =>
            {
                options.HasMany(x => x.RobotCampaigns).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.MachineCampaigns).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.CampaignSelections).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.AccumulationPoints).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.SpinHistories).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.CampaignRewardRules).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
                options.HasMany(x => x.CampaignGifts).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId);
            });

            // Gift
            modelBuilder.Entity<Gift>(options =>
            {
                options.HasMany(x => x.CampaignGifts).WithOne(x => x.Gift).HasForeignKey(x => x.GiftId);
                options.HasMany(x => x.Rewards).WithOne(x => x.Gift).HasForeignKey(x => x.GiftId);
                options.HasMany(x => x.GiftRewardRules).WithOne(x => x.Gift).HasForeignKey(x => x.GiftId);
            });

            // Reward Rule
            modelBuilder.Entity<RewardRule>(options =>
            {
                options.HasMany(x => x.GiftRewardRules).WithOne(x => x.RewardRule).HasForeignKey(x => x.RewardRuleId);
                options.HasMany(x => x.CampaignRewardRules).WithOne(x => x.RewardRule).HasForeignKey(x => x.RewardRuleId);
            });

            // Area
            modelBuilder.Entity<Area>(options =>
            {
                options.HasMany(x => x.Provinces).WithOne(x => x.Area).HasForeignKey(x => x.AreaId);
            });

            // Province
            modelBuilder.Entity<Province>(options =>
            {
                options.HasMany(x => x.Locations).WithOne(x => x.Province).HasForeignKey(x => x.ProvinceId);
            });
            // Location
            modelBuilder.Entity<Location>(options =>
            {
                options.HasMany(x => x.Campaigns).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
            });

            #endregion

            #region Cac khoa vua la khoa chinh vua va khoa ngoai

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.RoleId, x.UserId });
            modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId });
            modelBuilder.Entity<MachineCampaign>().HasKey(x => new { x.CampaignId, x.MachineId });
            modelBuilder.Entity<RobotCampaign>().HasKey(x => new { x.CampaignId, x.RobotId });
            modelBuilder.Entity<CampaignSelection>().HasKey(x => new { x.CampaignId, x.UserId });
            modelBuilder.Entity<CampaignGift>().HasKey(x => new { x.CampaignId, x.GiftId });
            modelBuilder.Entity<GiftRewardRule>().HasKey(x => new { x.RewardRuleId, x.GiftId });
            modelBuilder.Entity<CampaignRewardRule>().HasKey(x => new { x.RewardRuleId, x.CampaignId });
            #endregion


            #region Thiet lap cac khoa unique
            modelBuilder.Entity<Robot>().HasIndex(x => x.RobotCode).IsUnique();
            modelBuilder.Entity<RecyclingMachine>().HasIndex(x => x.MachineCode).IsUnique();
            modelBuilder.Entity<Location>().HasIndex(x => x.LocationName).IsUnique();
            modelBuilder.Entity<Province>().HasIndex(x => x.ProvinceName).IsUnique();
            modelBuilder.Entity<Area>().HasIndex(x => x.AreaName).IsUnique();
            modelBuilder.Entity<RewardRule>().HasIndex(x => x.RuleName).IsUnique();
            modelBuilder.Entity<Gift>().HasIndex(x => x.GiftName).IsUnique();
            modelBuilder.Entity<Campaign>().HasIndex(x => x.CampaignName).IsUnique();
            modelBuilder.Entity<PermissionGroup>().HasIndex(x => x.GroupName).IsUnique();
            modelBuilder.Entity<User>(opt =>
            {
                opt.HasIndex(x => x.Username).IsUnique();
                opt.HasIndex(x => x.Email).IsUnique();
            });

            #endregion


            // Thiet lap cac action delete
            var entities = modelBuilder.Model.GetEntityTypes();
            foreach (var item in entities)
            {
                var fk = item.GetForeignKeys();
                foreach (var item1 in fk)
                {
                    item1.DeleteBehavior = DeleteBehavior.NoAction;
                }
            }
        }
    }
}
