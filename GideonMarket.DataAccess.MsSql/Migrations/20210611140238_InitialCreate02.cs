using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GideonMarket.DataAccess.MsSql.Migrations
{
    public partial class InitialCreate02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 11, 20, 2, 35, 769, DateTimeKind.Local).AddTicks(3911),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 3, 13, 47, 42, 859, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Incomes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 3, 13, 47, 42, 859, DateTimeKind.Local).AddTicks(3435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 11, 20, 2, 35, 769, DateTimeKind.Local).AddTicks(3911));
        }
    }
}
