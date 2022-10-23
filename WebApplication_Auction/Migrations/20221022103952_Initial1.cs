using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 22, 12, 39, 52, 489, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 22, 12, 39, 52, 489, DateTimeKind.Local).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 22, 12, 39, 52, 489, DateTimeKind.Local).AddTicks(413));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3655));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "LastUpdated",
                value: new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3651));
        }
    }
}
