﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartingBid = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDbs_UserDbs_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BidDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDbs_AuctionDbs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserDbs",
                columns: new[] { "Id", "Name", "Username" },
                values: new object[] { -1, "the user", "user123" });

            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Description", "ExpirationDate", "Name", "StartingBid", "StartingDate", "UserId" },
                values: new object[] { -1, "OLED TV from Samsung", new DateTime(2023, 12, 12, 2, 30, 50, 0, DateTimeKind.Unspecified), "TV", 150, new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2205), -1 });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionId", "Date" },
                values: new object[] { -2, 80, -1, new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2311) });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionId", "Date" },
                values: new object[] { -1, 50, -1, new DateTime(2022, 10, 18, 17, 38, 34, 821, DateTimeKind.Local).AddTicks(2305) });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDbs_UserId",
                table: "AuctionDbs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BidDbs_AuctionId",
                table: "BidDbs",
                column: "AuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDbs");

            migrationBuilder.DropTable(
                name: "AuctionDbs");

            migrationBuilder.DropTable(
                name: "UserDbs");
        }
    }
}
