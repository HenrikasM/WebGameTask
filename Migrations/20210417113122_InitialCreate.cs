using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebGameTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameTasks",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Input = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Output = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTasks", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTasks");

            migrationBuilder.DropTable(
                name: "Solutions");
        }
    }
}
