using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorCRUDApp.Migrations
{
    /// <inheritdoc />
    public partial class AddLibrarySong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibrarySong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrarySong", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LibrarySong",
                columns: new[] { "Id", "Artist", "Title" },
                values: new object[,]
                {
                    { 1, "John Lennon", "Imagine" },
                    { 2, "The Beatles", "Let It Be" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrarySong");
        }
    }
}
