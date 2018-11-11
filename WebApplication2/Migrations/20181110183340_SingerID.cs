using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class SingerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Singer_SingerID1",
                table: "Tour");

            migrationBuilder.RenameColumn(
                name: "SingerID1",
                table: "Tour",
                newName: "SingerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_SingerID1",
                table: "Tour",
                newName: "IX_Tour_SingerID");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastConection",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Singer_SingerID",
                table: "Tour",
                column: "SingerID",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Singer_SingerID1",
                table: "Tour");

            migrationBuilder.RenameColumn(
                name: "SingerID1",
                table: "Tour",
                newName: "SingerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_SingerID1",
                table: "Tour",
                newName: "IX_Tour_SingerID");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastConection",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Singer_SingerID",
                table: "Tour",
                column: "SingerID",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
