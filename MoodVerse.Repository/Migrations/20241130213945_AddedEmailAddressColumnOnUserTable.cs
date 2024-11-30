using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailAddressColumnOnUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "User");
        }
    }
}
