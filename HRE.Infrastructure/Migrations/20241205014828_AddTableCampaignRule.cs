using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCampaignRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignRules",
                columns: table => new
                {
                    RuleId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRules", x => new { x.CampaignId, x.RuleId });
                    table.ForeignKey(
                        name: "FK_CampaignRules_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignRules_GiftRules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "GiftRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRules_RuleId",
                table: "CampaignRules",
                column: "RuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignRules");
        }
    }
}
