using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MoodTubeOriginal.Migrations
{
    public partial class ApplicationUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                   name: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
