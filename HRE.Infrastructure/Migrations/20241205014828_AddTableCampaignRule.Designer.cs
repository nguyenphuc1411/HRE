﻿// <auto-generated />
using System;
using HRE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241205014828_AddTableCampaignRule")]
    partial class AddTableCampaignRule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRE.Domain.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("InitialQuantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityGiven")
                        .HasColumnType("int");

                    b.Property<int>("WinningRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("GiftId");

                    b.ToTable("CampaignGifts");
                });

            modelBuilder.Entity("HRE.Domain.Entities.CampaignRule", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.HasKey("CampaignId", "RuleId");

                    b.HasIndex("RuleId");

                    b.ToTable("CampaignRules");
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

            modelBuilder.Entity("HRE.Domain.Entities.GiftInRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.Property<int>("WinningRate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GiftId");

                    b.HasIndex("RuleId");

                    b.ToTable("GiftInRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRedemption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .HasColumnType("Nvarchar(150)");

                    b.Property<string>("CustomerPhone")
                        .HasColumnType("Varchar(11)");

                    b.Property<int>("PGStaffId")
                        .HasColumnType("int");

                    b.Property<int>("QRCodeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RedemptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("Nvarchar(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PGStaffId");

                    b.HasIndex("QRCodeId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("GiftRedemptions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PGStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("Nvarchar(255)");

                    b.Property<int>("RedemptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PGStaffId");

                    b.HasIndex("RedemptionId")
                        .IsUnique();

                    b.ToTable("GiftReturns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<int>("MaxPoints")
                        .HasColumnType("int");

                    b.Property<int>("MinPoints")
                        .HasColumnType("int");

                    b.Property<string>("RuleName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RuleName")
                        .IsUnique();

                    b.ToTable("GiftRules");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Addesss")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("Decimal(9,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("Nvarchar(255)");

                    b.Property<string>("Province_City")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("Name")
                        .IsUnique();

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

            modelBuilder.Entity("HRE.Domain.Entities.QRCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InteractionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssuedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QRCodeURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UsedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InteractionId")
                        .IsUnique();

                    b.ToTable("QRCodes");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RecyclingMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessCount")
                        .HasColumnType("int");

                    b.Property<bool>("BinStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("MachineCode")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MachineCode")
                        .IsUnique();

                    b.ToTable("RecyclingMachines");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Robot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BatteryLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastAccess")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("RobotCode")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.Property<string>("RobotType")
                        .IsRequired()
                        .HasColumnType("Varchar(20)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

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

            modelBuilder.Entity("HRE.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("Varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserInteraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GiftId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSpun")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWon")
                        .HasColumnType("bit");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("PointEarned")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("GiftId");

                    b.HasIndex("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInteractions");
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

            modelBuilder.Entity("HRE.Domain.Entities.CampaignRule", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("CampaignRules")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.GiftRule", "GiftRule")
                        .WithMany("CampaignRules")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("GiftRule");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftInRule", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Gift", "Gift")
                        .WithMany("GiftInRules")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.GiftRule", "GiftRule")
                        .WithMany("GiftInRules")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("GiftRule");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRedemption", b =>
                {
                    b.HasOne("HRE.Domain.Entities.User", "PGStaff")
                        .WithMany("GiftRedemptionPGs")
                        .HasForeignKey("PGStaffId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.QRCode", "QRCode")
                        .WithOne("GiftRedemption")
                        .HasForeignKey("HRE.Domain.Entities.GiftRedemption", "QRCodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("GiftRedemptionUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PGStaff");

                    b.Navigation("QRCode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftReturn", b =>
                {
                    b.HasOne("HRE.Domain.Entities.User", "PGStaff")
                        .WithMany("GiftReturns")
                        .HasForeignKey("PGStaffId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.GiftRedemption", "GiftRedemption")
                        .WithOne("GiftReturn")
                        .HasForeignKey("HRE.Domain.Entities.GiftReturn", "RedemptionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GiftRedemption");

                    b.Navigation("PGStaff");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Location", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Area", "Area")
                        .WithMany("Locations")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Area");
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

            modelBuilder.Entity("HRE.Domain.Entities.QRCode", b =>
                {
                    b.HasOne("HRE.Domain.Entities.UserInteraction", "UserInteraction")
                        .WithOne("QRCode")
                        .HasForeignKey("HRE.Domain.Entities.QRCode", "InteractionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserInteraction");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RecyclingMachine", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Robot", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Location");
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

            modelBuilder.Entity("HRE.Domain.Entities.User", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserInteraction", b =>
                {
                    b.HasOne("HRE.Domain.Entities.Campaign", "Campaign")
                        .WithMany("UserInteractions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.Gift", "Gift")
                        .WithMany("UserInteractions")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HRE.Domain.Entities.RecyclingMachine", "RecyclingMachine")
                        .WithMany("UserInteractions")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HRE.Domain.Entities.User", "User")
                        .WithMany("UserInteractions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Gift");

                    b.Navigation("RecyclingMachine");

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
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Campaign", b =>
                {
                    b.Navigation("CampaignGifts");

                    b.Navigation("CampaignRules");

                    b.Navigation("MachineCampaigns");

                    b.Navigation("RobotCampaigns");

                    b.Navigation("UserInteractions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Gift", b =>
                {
                    b.Navigation("CampaignGifts");

                    b.Navigation("GiftInRules");

                    b.Navigation("UserInteractions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRedemption", b =>
                {
                    b.Navigation("GiftReturn");
                });

            modelBuilder.Entity("HRE.Domain.Entities.GiftRule", b =>
                {
                    b.Navigation("CampaignRules");

                    b.Navigation("GiftInRules");
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

            modelBuilder.Entity("HRE.Domain.Entities.QRCode", b =>
                {
                    b.Navigation("GiftRedemption");
                });

            modelBuilder.Entity("HRE.Domain.Entities.RecyclingMachine", b =>
                {
                    b.Navigation("MachineCampaigns");

                    b.Navigation("UserInteractions");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Robot", b =>
                {
                    b.Navigation("RobotCampaigns");
                });

            modelBuilder.Entity("HRE.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HRE.Domain.Entities.User", b =>
                {
                    b.Navigation("GiftRedemptionPGs");

                    b.Navigation("GiftRedemptionUsers");

                    b.Navigation("GiftReturns");

                    b.Navigation("UserInteractions");

                    b.Navigation("UserTokens");
                });

            modelBuilder.Entity("HRE.Domain.Entities.UserInteraction", b =>
                {
                    b.Navigation("QRCode");
                });
#pragma warning restore 612, 618
        }
    }
}
