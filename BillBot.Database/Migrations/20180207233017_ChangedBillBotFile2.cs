using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BillBot.Database.Migrations
{
    public partial class ChangedBillBotFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BillBotFiles",
                newName: "FileType");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BillBotFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BillBotFiles");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "BillBotFiles",
                newName: "Name");
        }
    }
}
