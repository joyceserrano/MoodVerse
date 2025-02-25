﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsernameToAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Account");
        }
    }
}
