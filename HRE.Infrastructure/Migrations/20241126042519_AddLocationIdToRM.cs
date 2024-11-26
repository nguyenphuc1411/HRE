using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationIdToRM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "RecyclingMachines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecyclingMachines_LocationId",
                table: "RecyclingMachines",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecyclingMachines_Locations_LocationId",
                table: "RecyclingMachines",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecyclingMachines_Locations_LocationId",
                table: "RecyclingMachines");

            migrationBuilder.DropIndex(
                name: "IX_RecyclingMachines_LocationId",
                table: "RecyclingMachines");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RecyclingMachines");
        }
    }
}
