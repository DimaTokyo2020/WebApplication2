using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class MariedWasBorn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Married",
                table: "Singer");

            migrationBuilder.DropColumn(
               name: "WasBorn",
               table: "Singer");

            migrationBuilder.AddColumn<bool>(
                name: "Married",
                table: "Singer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WasBorn",
                table: "Singer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Married",
                table: "Singer");

            migrationBuilder.DropColumn(
                name: "WasBorn",
                table: "Singer");
        }
    }
}
