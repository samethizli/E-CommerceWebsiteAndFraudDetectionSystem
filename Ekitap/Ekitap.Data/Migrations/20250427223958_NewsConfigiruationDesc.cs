using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ekitap.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewsConfigiruationDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "PublishingHouses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(750)",
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 39, 57, 522, DateTimeKind.Local).AddTicks(7246), new Guid("5c43eabc-f045-4e8f-b585-8739a2f3544f") });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 4, 28, 1, 39, 57, 524, DateTimeKind.Local).AddTicks(3440), new Guid("7f48f6a5-ae5e-4013-bff9-4b2fb718f3fd") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "PublishingHouses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "News",
                type: "nvarchar(750)",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 18, 18, 58, 21, 330, DateTimeKind.Local).AddTicks(6829), new Guid("9c38e15a-b2b5-4d74-b8fa-54b02cfffbb4") });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 2, 18, 18, 58, 21, 332, DateTimeKind.Local).AddTicks(2148), new Guid("c8ae275b-2211-4d43-bf06-a92d60d3fdf4") });
        }
    }
}
