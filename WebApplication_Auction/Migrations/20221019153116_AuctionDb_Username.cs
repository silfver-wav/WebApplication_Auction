using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    public partial class AuctionDb_Username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AuctionDbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "StartingDate", "UserName" },
                values: new object[] { new DateTime(2022, 10, 19, 17, 31, 16, 180, DateTimeKind.Local).AddTicks(3649), "user123" });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "Date",
                value: new DateTime(2022, 10, 19, 17, 31, 16, 180, DateTimeKind.Local).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2022, 10, 19, 17, 31, 16, 180, DateTimeKind.Local).AddTicks(3695));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AuctionDbs");

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
    }
}
