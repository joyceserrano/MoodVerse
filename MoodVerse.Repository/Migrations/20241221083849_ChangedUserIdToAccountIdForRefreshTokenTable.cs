using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserIdToAccountIdForRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RefreshToken",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Account_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Account_AccountId",
                table: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "RefreshToken",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                newName: "IX_RefreshToken_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
