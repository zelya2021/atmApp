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
                value: new DateTime(2021, 11, 6, 1, 8, 0, 381, DateTimeKind.Local).AddTicks(6318));

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "AccountBalance", "CardId", "NameOfOperation", "Time", "WithdrawnAmount" },
                values: new object[] { 3, 1220m, 1, "cash withdrawal", new DateTime(2021, 11, 6, 1, 8, 0, 383, DateTimeKind.Local).AddTicks(1776), 1000m });

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "AccountBalance", "CardId", "NameOfOperation", "Time", "WithdrawnAmount" },
                values: new object[] { 2, 2220m, 1, "balance", new DateTime(2021, 11, 6, 1, 8, 0, 383, DateTimeKind.Local).AddTicks(1750), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Operation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 11, 6, 0, 50, 53, 465, DateTimeKind.Local).AddTicks(5407));
        }
    }
}
