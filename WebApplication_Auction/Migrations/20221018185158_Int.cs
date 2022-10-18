using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    public partial class Int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "StartingDate",
                value: new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3601));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2022, 10, 18, 20, 51, 58, 209, DateTimeKind.Local).AddTicks(3596));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "StartingDate",
                value: new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2305));
        }
    }
}
