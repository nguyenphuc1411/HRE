using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCampaignGift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WinningRate",
                table: "CampaignGifts",
                newName: "WonQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WonQuantity",
                table: "CampaignGifts",
                newName: "WinningRate");
        }
    }
}
