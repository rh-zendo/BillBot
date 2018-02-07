using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BillBot.Database.Migrations
{
    public partial class ChangeDiscordUserIdtoUlong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KarmaPoints",
                table: "DiscordUsers",
                newName: "Level");

            migrationBuilder.AlterColumn<ulong>(
                name: "DiscordId",
                table: "DiscordUsers",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "DiscordUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Karma",
                table: "DiscordUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "DiscordUsers");

            migrationBuilder.DropColumn(
                name: "Karma",
                table: "DiscordUsers");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "DiscordUsers",
                newName: "KarmaPoints");

            migrationBuilder.AlterColumn<long>(
                name: "DiscordId",
                table: "DiscordUsers",
                nullable: false,
                oldClrType: typeof(ulong));
        }
    }
}
