﻿// <auto-generated />
using System;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRE.Domain.Entities.AccumulationPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("UserId");

                    b.ToTable("AccumulationPoints");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("NVarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AreaName")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CampaignName")
                        .IsUnique();

                    b.HasIndex("LocationId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignGift", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CampaignId", "GiftId");

                    b.HasIndex("GiftId");

                    b.ToTable("CampaignGifts");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignRewardRule", b =>
                {
                    b.Property<int>("RewardRuleId")
                        .HasColumnType("int");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.HasKey("RewardRuleId", "CampaignId");

                    b.HasIndex("CampaignId");

                    b.ToTable("CampaignRewardRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignSelection", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CampaignId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("CampaignSelections");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GiftName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("GiftName")
                        .IsUnique();

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRewardRule", b =>
                {
                    b.Property<int>("RewardRuleId")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("WinningPercentage")
                        .HasColumnType("int");

                    b.HasKey("RewardRuleId", "GiftId");

                    b.HasIndex("GiftId");

                    b.ToTable("GiftRewardRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("Decimal(9,6)");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("Decimal(9,6)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LocationName")
                        .IsUnique();

                    b.HasIndex("ProvinceId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HRE.Domain.Entities.MachineCampaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignId", "MachineId");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineCampaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.PermissionGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("GroupName")
                        .IsUnique();

                    b.ToTable("PermissionGroups");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ProvinceName")
                        .IsUnique();

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RecyclingMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("Nvarchar(20)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLocation")
                        .HasColumnType("Nvarchar(255)");

                    b.Property<string>("MachineCode")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MachineCode")
                        .IsUnique();

                    b.ToTable("RecyclingMachines");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RedemptionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("Nvarchar(10)");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PerformBy")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("Nvarchar(255)");

                    b.Property<int>("RedemptionID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerformBy");

                    b.HasIndex("RedemptionID");

                    b.ToTable("RedemptionHistories");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("QRCode")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GiftId");

                    b.ToTable("Rewards");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RewardRedemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .HasColumnType("Nvarchar(150)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("Varchar(11)");

                    b.Property<int>("RedeemedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RedemptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RewardId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("Nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("RedeemedBy");

                    b.HasIndex("RewardId")
                        .IsUnique();

                    b.ToTable("RewardRedemptions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RewardRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EndRange")
                        .HasColumnType("int");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<int>("StartRange")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RuleName")
                        .IsUnique();

                    b.ToTable("RewardRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatteryLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastLocation")
                        .HasColumnType("Nvarchar(255)");

                    b.Property<string>("RobotCode")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("RobotName")
                        .IsRequired()
                        .HasColumnType("NVarchar(255)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("Varchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("RobotCode")
                        .IsUnique();

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RobotCampaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignId", "RobotId");

                    b.HasIndex("RobotId");

                    b.ToTable("RobotCampaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.SpinHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("PointsUsed")
                        .HasColumnType("int");

                    b.Property<int?>("RewardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SpinDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("RewardId")
                        .IsUnique()
                        .HasFilter("[RewardId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("SpinHistories");
                });

            modelBuilder.Entity("HRE.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("NVarchar(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("Varchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("Varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("HRE.Domain.Entities.AccumulationPoint", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("AccumulationPoints")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("AccumulationPoints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Campaign", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Location", "Location")
                        .WithMany("Campaigns")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignGift", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("CampaignGifts")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Gift", "Gift")
                        .WithMany("CampaignGifts")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignRewardRule", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("CampaignRewardRules")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.RewardRule", "RewardRule")
                        .WithMany("CampaignRewardRules")
                        .HasForeignKey("RewardRuleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("RewardRule");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignSelection", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("CampaignSelections")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("CampaignSelections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRewardRule", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Gift", "Gift")
                        .WithMany("GiftRewardRules")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.RewardRule", "RewardRule")
                        .WithMany("GiftRewardRules")
                        .HasForeignKey("RewardRuleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("RewardRule");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Location", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Province", "Province")
                        .WithMany("Locations")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("HRE.Domain.Entities.MachineCampaign", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("MachineCampaigns")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.RecyclingMachine", "Machine")
                        .WithMany("MachineCampaigns")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Permission", b =>
                {
                    b.HasOne("HRE.Domain.Entities.PermissionGroup", "PermissionGroup")
                        .WithMany("Permissions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PermissionGroup");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Province", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Area", "Area")
                        .WithMany("Provinces")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RedemptionHistory", b =>
                {
                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("RedemptionHistories")
                        .HasForeignKey("PerformBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.RewardRedemption", "RewardRedemption")
                        .WithMany("RedemptionHistories")
                        .HasForeignKey("RedemptionID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RewardRedemption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Reward", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Gift", "Gift")
                        .WithMany("Rewards")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RewardRedemption", b =>
                {
                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("RewardRedemptions")
                        .HasForeignKey("RedeemedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Reward", "Reward")
                        .WithOne("RewardRedemption")
                        .HasForeignKey("HRE.Domain.Entities.RewardRedemption", "RewardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reward");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RobotCampaign", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("RobotCampaigns")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Robot", "Robot")
                        .WithMany("RobotCampaigns")
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Robot");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HRE.Domain.Entities.SpinHistory", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("SpinHistories")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Reward", "Reward")
                        .WithOne("SpinHistory")
                        .HasForeignKey("HRE.Domain.Entities.SpinHistory", "RewardId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("SpinHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Reward");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserToken", b =>
                {
                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Area", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Campaign", b =>
                {
                    b.Navigation("AccumulationPoints");

                    b.Navigation("CampaignGifts");

                    b.Navigation("CampaignRewardRules");

                    b.Navigation("CampaignSelections");

                    b.Navigation("MachineCampaigns");

                    b.Navigation("RobotCampaigns");

                    b.Navigation("SpinHistories");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Gift", b =>
                {
                    b.Navigation("CampaignGifts");

                    b.Navigation("GiftRewardRules");

                    b.Navigation("Rewards");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Location", b =>
                {
                    b.Navigation("Campaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.PermissionGroup", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Province", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RecyclingMachine", b =>
                {
                    b.Navigation("MachineCampaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Reward", b =>
                {
                    b.Navigation("RewardRedemption");

                    b.Navigation("SpinHistory")
                        .IsRequired();
                });

            modelBuilder.Entity("HRE.Domain.Entities.RewardRedemption", b =>
                {
                    b.Navigation("RedemptionHistories");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RewardRule", b =>
                {
                    b.Navigation("CampaignRewardRules");

                    b.Navigation("GiftRewardRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Robot", b =>
                {
                    b.Navigation("RobotCampaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("HRE.Domain.Entities.User", b =>
                {
                    b.Navigation("AccumulationPoints");

                    b.Navigation("CampaignSelections");

                    b.Navigation("RedemptionHistories");

                    b.Navigation("RewardRedemptions");

                    b.Navigation("SpinHistories");

                    b.Navigation("UserRoles");

                    b.Navigation("UserTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
