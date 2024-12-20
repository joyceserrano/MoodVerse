using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedTitleOnNoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Note",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Note");
        }
    }
}
