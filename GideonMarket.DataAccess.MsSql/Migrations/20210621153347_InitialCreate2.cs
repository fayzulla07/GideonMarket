using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GideonMarket.DataAccess.MsSql.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 21, 21, 33, 46, 150, DateTimeKind.Local).AddTicks(7827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 21, 21, 13, 45, 911, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_PriceListId",
                table: "Incomes",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_PriceLists_PriceListId",
                table: "Incomes",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_PriceLists_PriceListId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_PriceListId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Incomes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 21, 21, 13, 45, 911, DateTimeKind.Local).AddTicks(4132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 21, 21, 33, 46, 150, DateTimeKind.Local).AddTicks(7827));
        }
    }
}
