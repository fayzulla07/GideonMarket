using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GideonMarket.DataAccess.MsSql.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 26, 19, 29, 17, 228, DateTimeKind.Local).AddTicks(2695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 21, 21, 40, 5, 78, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.AddColumn<int>(
                name: "PriceListId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PriceListId",
                table: "Customers",
                column: "PriceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PriceListId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PriceListId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 21, 21, 40, 5, 78, DateTimeKind.Local).AddTicks(1332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 26, 19, 29, 17, 228, DateTimeKind.Local).AddTicks(2695));
        }
    }
}
