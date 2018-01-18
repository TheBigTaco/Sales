using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebsite.Migrations
{
    public partial class TempFixs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "temps",
                columns: table => new
                {
                    City = table.Column<string>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    Country = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temps", x => x.City);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "temps");
        }
    }
}
