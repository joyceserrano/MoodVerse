using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RenamedNotesTableToNoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryEmotionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_PrimaryEmotionType_PrimaryEmotionTypeId",
                        column: x => x.PrimaryEmotionTypeId,
                        principalTable: "PrimaryEmotionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_User_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_CreatorId",
                table: "Note",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ModifierId",
                table: "Note",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_PrimaryEmotionTypeId",
                table: "Note",
                column: "PrimaryEmotionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrimaryEmotionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_PrimaryEmotionType_PrimaryEmotionTypeId",
                        column: x => x.PrimaryEmotionTypeId,
                        principalTable: "PrimaryEmotionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_User_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatorId",
                table: "Notes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ModifierId",
                table: "Notes",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PrimaryEmotionTypeId",
                table: "Notes",
                column: "PrimaryEmotionTypeId");
        }
    }
}
