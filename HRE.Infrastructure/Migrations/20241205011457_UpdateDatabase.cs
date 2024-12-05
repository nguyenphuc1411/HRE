using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignGiftRules");

            migrationBuilder.DropTable(
                name: "RewardReturnHistories");

            migrationBuilder.DropTable(
                name: "SpinHistories");

            migrationBuilder.DropTable(
                name: "UserPoints");

            migrationBuilder.DropTable(
                name: "RewardRedemptions");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.RenameColumn(
                name: "Probability",
                table: "GiftInRules",
                newName: "WinningRate");

            migrationBuilder.CreateTable(
                name: "CampaignGifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    WinningRate = table.Column<int>(type: "int", nullable: false),
                    InitialQuantity = table.Column<int>(type: "int", nullable: false),
                    QuantityGiven = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignGifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignGifts_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignGifts_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserInteractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GiftId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointEarned = table.Column<int>(type: "int", nullable: false),
                    IsSpun = table.Column<bool>(type: "bit", nullable: false),
                    IsWon = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInteractions_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInteractions_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInteractions_RecyclingMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "RecyclingMachines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserInteractions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QRCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteractionId = table.Column<int>(type: "int", nullable: false),
                    QRCodeURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QRCodes_UserInteractions_InteractionId",
                        column: x => x.InteractionId,
                        principalTable: "UserInteractions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiftRedemptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QRCodeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PGStaffId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "Nvarchar(150)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "Varchar(11)", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "Nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftRedemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftRedemptions_QRCodes_QRCodeId",
                        column: x => x.QRCodeId,
                        principalTable: "QRCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiftRedemptions_Users_PGStaffId",
                        column: x => x.PGStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiftRedemptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GiftReturns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedemptionId = table.Column<int>(type: "int", nullable: false),
                    PGStaffId = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "Nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftReturns_GiftRedemptions_RedemptionId",
                        column: x => x.RedemptionId,
                        principalTable: "GiftRedemptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GiftReturns_Users_PGStaffId",
                        column: x => x.PGStaffId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGifts_CampaignId",
                table: "CampaignGifts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGifts_GiftId",
                table: "CampaignGifts",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemptions_PGStaffId",
                table: "GiftRedemptions",
                column: "PGStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemptions_QRCodeId",
                table: "GiftRedemptions",
                column: "QRCodeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemptions_UserId",
                table: "GiftRedemptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftReturns_PGStaffId",
                table: "GiftReturns",
                column: "PGStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftReturns_RedemptionId",
                table: "GiftReturns",
                column: "RedemptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRCodes_InteractionId",
                table: "QRCodes",
                column: "InteractionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_CampaignId",
                table: "UserInteractions",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_GiftId",
                table: "UserInteractions",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_MachineId",
                table: "UserInteractions",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractions_UserId",
                table: "UserInteractions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignGifts");

            migrationBuilder.DropTable(
                name: "GiftReturns");

            migrationBuilder.DropTable(
                name: "GiftRedemptions");

            migrationBuilder.DropTable(
                name: "QRCodes");

            migrationBuilder.DropTable(
                name: "UserInteractions");

            migrationBuilder.RenameColumn(
                name: "WinningRate",
                table: "GiftInRules",
                newName: "Probability");

            migrationBuilder.CreateTable(
                name: "CampaignGiftRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    GiftInRuleId = table.Column<int>(type: "int", nullable: false),
                    InitialQuantity = table.Column<int>(type: "int", nullable: false),
                    QuantityGiven = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignGiftRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignGiftRules_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignGiftRules_GiftInRules_GiftInRuleId",
                        column: x => x.GiftInRuleId,
                        principalTable: "GiftInRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftId = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    QRCode = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Gifts_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPoints_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RewardRedemptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "Nvarchar(150)", nullable: true),
                    CustomerPhone = table.Column<string>(type: "Varchar(11)", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "Nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardRedemptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardRedemptions_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RewardRedemptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpinHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    RewardId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PointsAtSpin = table.Column<int>(type: "int", nullable: false),
                    SpinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpinResult = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpinHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpinHistories_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpinHistories_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpinHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RewardReturnHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedemptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "Nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardReturnHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardReturnHistories_RewardRedemptions_RedemptionId",
                        column: x => x.RedemptionId,
                        principalTable: "RewardRedemptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RewardReturnHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGiftRules_CampaignId",
                table: "CampaignGiftRules",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGiftRules_GiftInRuleId",
                table: "CampaignGiftRules",
                column: "GiftInRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardRedemptions_RewardId",
                table: "RewardRedemptions",
                column: "RewardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RewardRedemptions_UserId",
                table: "RewardRedemptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardReturnHistories_RedemptionId",
                table: "RewardReturnHistories",
                column: "RedemptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RewardReturnHistories_UserId",
                table: "RewardReturnHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_GiftId",
                table: "Rewards",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_SpinHistories_CampaignId",
                table: "SpinHistories",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_SpinHistories_RewardId",
                table: "SpinHistories",
                column: "RewardId",
                unique: true,
                filter: "[RewardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SpinHistories_UserId",
                table: "SpinHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_CampaignId",
                table: "UserPoints",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPoints_UserId",
                table: "UserPoints",
                column: "UserId");
        }
    }
}
