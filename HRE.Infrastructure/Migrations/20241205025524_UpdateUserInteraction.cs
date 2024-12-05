using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserInteractions");

            migrationBuilder.AlterColumn<int>(
                name: "PointEarned",
                table: "UserInteractions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsWon",
                table: "UserInteractions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "UserInteractions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SpunDate",
                table: "UserInteractions",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "UserInteractions");

            migrationBuilder.DropColumn(
                name: "SpunDate",
                table: "UserInteractions");

            migrationBuilder.AlterColumn<int>(
                name: "PointEarned",
                table: "UserInteractions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsWon",
                table: "UserInteractions",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserInteractions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
