using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.AddColumn<string>(
                name: "MoodName",
                table: "Mood",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLocation",
                table: "AspNetUsers",
                nullable: true);

           
        

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Singer_SingerID",
                table: "Tour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tour",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Tour_SingerID",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "TourID",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "When",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "MoodName",
                table: "Mood");

            migrationBuilder.DropColumn(
                name: "UserLocation",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Tour",
                newName: "MoodTubeOriginal.Models.Tour");

            migrationBuilder.AddForeignKey(
                name: "FK_MoodTubeOriginal.Models.Tour_Singer_SingerID",
                table: "MoodTubeOriginal.Models.Tour",
                column: "SingerID",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
