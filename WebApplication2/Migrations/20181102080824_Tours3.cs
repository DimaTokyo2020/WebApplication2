using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class Tours3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
               name: "Tour");

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourID = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    SingerID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourID);
                    table.ForeignKey(
                        name: "FK_Tour_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "SingerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tour_SingerID",
                table: "Tour",
                column: "SingerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
