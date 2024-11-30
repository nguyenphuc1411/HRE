using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGiftRuleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftInRules_GetRules_RuleId",
                table: "GiftInRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetRules",
                table: "GetRules");

            migrationBuilder.RenameTable(
                name: "GetRules",
                newName: "GiftRules");

            migrationBuilder.RenameIndex(
                name: "IX_GetRules_RuleName",
                table: "GiftRules",
                newName: "IX_GiftRules_RuleName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftRules",
                table: "GiftRules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftInRules_GiftRules_RuleId",
                table: "GiftInRules",
                column: "RuleId",
                principalTable: "GiftRules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftInRules_GiftRules_RuleId",
                table: "GiftInRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftRules",
                table: "GiftRules");

            migrationBuilder.RenameTable(
                name: "GiftRules",
                newName: "GetRules");

            migrationBuilder.RenameIndex(
                name: "IX_GiftRules_RuleName",
                table: "GetRules",
                newName: "IX_GetRules_RuleName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetRules",
                table: "GetRules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftInRules_GetRules_RuleId",
                table: "GiftInRules",
                column: "RuleId",
                principalTable: "GetRules",
                principalColumn: "Id");
        }
    }
}
