using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GideonMarket.DataAccess.MsSql.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 29, 21, 52, 40, 703, DateTimeKind.Local).AddTicks(6245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 26, 20, 25, 57, 760, DateTimeKind.Local).AddTicks(9211));

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Incomes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Incomes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PriceListId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 26, 20, 25, 57, 760, DateTimeKind.Local).AddTicks(9211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 29, 21, 52, 40, 703, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Incomes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Incomes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PriceListId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PriceLists_PriceListId",
                table: "Customers",
                column: "PriceListId",
                principalTable: "PriceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
