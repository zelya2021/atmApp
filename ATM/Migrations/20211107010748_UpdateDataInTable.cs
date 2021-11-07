using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM.Migrations
{
    public partial class UpdateDataInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 7, 48, 479, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 7, 48, 481, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 7, 48, 481, DateTimeKind.Local).AddTicks(3947));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 6, 16, 610, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 6, 16, 611, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2021, 11, 7, 3, 6, 16, 611, DateTimeKind.Local).AddTicks(7522));
        }
    }
}
