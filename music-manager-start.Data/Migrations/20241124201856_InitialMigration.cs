using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace music_manager_start.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SongId = table.Column<string>(type: "TEXT", nullable: false),
                    rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Artist = table.Column<string>(type: "TEXT", nullable: false),
                    Album = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "SongId", "rating" },
                values: new object[,]
                {
                    { new Guid("1279430c-d55a-4a6e-a1ac-b12da285bdfe"), "dd906bcb-12b7-4cb1-9231-603d4f544390", 2 },
                    { new Guid("2051fcc5-c41f-46d5-87d3-2520c151df2a"), "ba62c87f-5a86-4f9b-85b5-16ba4ad39e30", 5 },
                    { new Guid("244c3b6c-ff3a-4b50-bda0-432116176d17"), "dd906bcb-12b7-4cb1-9231-603d4f544390", 4 },
                    { new Guid("3f640e8e-2517-4a2a-86ae-527279888015"), "6134ece0-f465-4102-b5e6-54afaebc1c19", 6 },
                    { new Guid("7ca7cf3d-811c-419f-8cb3-f77f0ad21982"), "22aa6f84-06d8-4a0e-bdad-3000b35b5b5f", 8 },
                    { new Guid("8fd2d752-e973-46d7-9ec2-088ef7b18f19"), "b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3", 9 },
                    { new Guid("d228aaad-0923-4ba6-8797-4f1ddedbc78f"), "42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e", 10 },
                    { new Guid("e4719187-9084-4a4b-a622-159c06cfe2eb"), "5d7686e9-b672-43d5-aec2-4bb3ffd9b665", 7 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "Artist", "FilePath", "Genre", "Title" },
                values: new object[,]
                {
                    { new Guid("22aa6f84-06d8-4a0e-bdad-3000b35b5b5f"), "Twelve Carat Toothache", "Post Malone", "/images/pm.png", "Hip Hop", "Something Real" },
                    { new Guid("42e4b4d5-93bb-4e46-bb6e-c57de62e7f6e"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.jpg", "Pop", "When the Party's Over" },
                    { new Guid("5d7686e9-b672-43d5-aec2-4bb3ffd9b665"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.jpg", "Pop", "Bad Guy" },
                    { new Guid("6134ece0-f465-4102-b5e6-54afaebc1c19"), "When We All Fall Asleep, Where Do We Go?", "Billie Eilish", "/images/be1.jpg", "Pop", "My Strange Addiction" },
                    { new Guid("b7cc1c82-77e2-40d0-8bc2-d7e05962c0e3"), "The Great Escape", "French Cassettes", "/images/fc.jpg", "Indie", "Utah" },
                    { new Guid("ba62c87f-5a86-4f9b-85b5-16ba4ad39e30"), "Hit Me Hard And Soft", "Billie Eilish", "/images/be2.png", "Pop", "Birds Of A Feather" },
                    { new Guid("dd906bcb-12b7-4cb1-9231-603d4f544390"), "Hit Me Hard And Soft", "Billie Eilish", "/images/be2.png", "Pop", "The Greatest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
