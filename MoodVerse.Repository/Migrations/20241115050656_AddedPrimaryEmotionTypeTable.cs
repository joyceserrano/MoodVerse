using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoodVerse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddedPrimaryEmotionTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimaryEmotionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryEmotionType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PrimaryEmotionType",
                columns: new[] { "Id", "Deleted", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("2ecd6a10-9b48-4ace-b067-41e64970b652"), false, "Sad", 2 },
                    { new Guid("8218caf3-2f43-4f25-8d93-a3799d4ed4b1"), false, "Happy", 1 },
                    { new Guid("9eb10e85-9dee-4cd4-b181-e8142dfe2ddc"), false, "Bad", 6 },
                    { new Guid("aabd1cf6-9828-4d67-9a24-3fe8084a5259"), false, "Disgusted", 3 },
                    { new Guid("c9157a17-c48c-4f92-946f-dcb13d0b9199"), false, "Surprised", 7 },
                    { new Guid("d3b6f6ba-0720-437d-80ec-edf9b463e469"), false, "Fearful", 5 },
                    { new Guid("f2a3fc65-5a98-4363-8103-4d0b30c9df45"), false, "Angry", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimaryEmotionType");
        }
    }
}
