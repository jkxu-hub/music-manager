using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_manager_start.Data.Migrations
{
    /// <inheritdoc />
    public partial class DemoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    Album = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "FilePath", "Genre", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"), "Twelve Carat Toothache", "Post Malone", "/images/pm.png", "Hip Hop", 10, "Something Real" },
                    { new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.png", "Pop", 10, "When the Party's Over" },
                    { new Guid("5d7686e9-b672-43d5-aec2-4bb3ffd9b665"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.png", "Pop", 10, "Bad Guy" },
                    { new Guid("6134ece0-f465-4102-b5e6-54afaebc1c19"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.png", "Pop", 10, "My Strange Addiction" },
                    { new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"), "The Great Escape", "French Cassettes", "/images/pb.png", "Indie", 10, "Utah" },
                    { new Guid("ba62c87f-5a86-4f9b-85b5-16ba4ad39e30"), "Hit Me Hard And Soft", "Billie Eilish", "/images/be2.png", "Pop", 10, "Birds Of A Feather" },
                    { new Guid("dd906bcb-12b7-4cb1-9231-603d4f544390"), "Hit Me Hard And Soft", "Billie Eilish", "/images/be2.png", "Pop", 10, "The Greatest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
