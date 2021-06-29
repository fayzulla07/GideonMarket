using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GideonMarket.DataAccess.MsSql.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 28, 23, 8, 33, 377, DateTimeKind.Local).AddTicks(2102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 28, 21, 42, 2, 804, DateTimeKind.Local).AddTicks(1078));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegDt",
                table: "Incomes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 6, 28, 21, 42, 2, 804, DateTimeKind.Local).AddTicks(1078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 6, 28, 23, 8, 33, 377, DateTimeKind.Local).AddTicks(2102));
        }
    }
}
