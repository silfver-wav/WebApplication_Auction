using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Auction.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskDbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskDbs_ProjectDbs_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectDbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectDbs",
                columns: new[] { "Id", "CreatedDate", "Description", "ExpirationDate", "StartingPrice", "Title", "UserName" },
                values: new object[] { -1, new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3311), "description", new DateTime(2023, 12, 12, 2, 30, 50, 0, DateTimeKind.Unspecified), 20, "Learning ASP.NET Core with MVC", "linus.silfver@gmail.com" });

            migrationBuilder.InsertData(
                table: "TaskDbs",
                columns: new[] { "Id", "Amount", "LastUpdated", "ProjectId", "Status", "UserName" },
                values: new object[] { -2, 100, new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3655), -1, 0, "victor@kth.se" });

            migrationBuilder.InsertData(
                table: "TaskDbs",
                columns: new[] { "Id", "Amount", "LastUpdated", "ProjectId", "Status", "UserName" },
                values: new object[] { -1, 50, new DateTime(2022, 10, 21, 23, 58, 2, 486, DateTimeKind.Local).AddTicks(3651), -1, 1, "linus@kth.se" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDbs_ProjectId",
                table: "TaskDbs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDbs");

            migrationBuilder.DropTable(
                name: "ProjectDbs");
        }
    }
}
