using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class DeleteSingerMarriedEditedToursSinger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Married",
                table: "Singer");

            migrationBuilder.DropColumn(
                name: "WasBorn",
                table: "Singer");

            /* migrationBuilder.RenameColumn(
                name: "SingerID1",
                table: "Tour",
                newName: "SingerID");

           migrationBuilder.RenameIndex(
                name: "IX_Tour_SingerID1",
                table: "Tour",
                newName: "IX_Tour_SingerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Singer_SingerID",
                table: "Tour",
                column: "SingerID",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Singer_SingerID",
                table: "Tour");

            migrationBuilder.RenameColumn(
                name: "SingerID",
                table: "Tour",
                newName: "SingerID1");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_SingerID",
                table: "Tour",
                newName: "IX_Tour_SingerID1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Singer_SingerID1",
                table: "Tour",
                column: "SingerID1",
                principalTable: "Singer",
                principalColumn: "SingerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
