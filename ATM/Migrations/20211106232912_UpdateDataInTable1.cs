using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM.Migrations
{
    public partial class UpdateDataInTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 5000m);

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "Id", "Balance", "CardNumber", "IsLocked", "NumberOfWrongAttempts", "PinCode" },
                values: new object[] { 2, 2000m, "1111-2222-3333-4444", false, 0, "1234" });

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 11, 7, 1, 29, 11, 633, DateTimeKind.Local).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2021, 11, 7, 1, 29, 11, 635, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2021, 11, 7, 1, 29, 11, 635, DateTimeKind.Local).AddTicks(461));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Card",
                keyColumn: "Id",
                keyValue: 1,
                column: "Balance",
                value: 2000m);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 11, 6, 1, 8, 0, 381, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2021, 11, 6, 1, 8, 0, 383, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2021, 11, 6, 1, 8, 0, 383, DateTimeKind.Local).AddTicks(1776));
        }
    }
}
