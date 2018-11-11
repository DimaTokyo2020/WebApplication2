using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class ToursLatitudeLogitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Latitude",
                table: "Tour",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Longitude",
                table: "Tour",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Tour");
        }
    }
}
