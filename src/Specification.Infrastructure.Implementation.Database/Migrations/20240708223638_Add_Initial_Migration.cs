using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Specification.Infrastructure.Implementation.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    release_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    mpaa_rating = table.Column<int>(type: "integer", nullable: false),
                    genre = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_movies", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "id", "genre", "mpaa_rating", "name", "rating", "release_date" },
                values: new object[,]
                {
                    { new Guid("272b950e-6835-4865-a924-c09750723145"), "Adventure", 3, "The Amazing Spider-Man", 7.0, new DateTime(2012, 7, 2, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4c5979b4-73af-49dc-b6ea-b9eed4bdc5ca"), "Fantasy", 2, "The Jungle Book", 7.5, new DateTime(2016, 4, 14, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("4f8eab4f-1eb6-49c3-9fca-f8cfb8cdc149"), "Adventure", 1, "The Secret Life of Pets", 6.5999999999999996, new DateTime(2016, 7, 7, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("6b125171-4cfc-4937-89cf-4b0d2384201d"), "Action", 4, "The Mummy", 6.7000000000000002, new DateTime(2017, 6, 8, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("7d5cbdb0-7068-4d75-8cdc-da5333cb446a"), "Horror", 3, "Split", 7.4000000000000004, new DateTime(2017, 1, 19, 21, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ad4f3d9b-3d1a-43b7-b408-fdcf157125c2"), "Family", 3, "Beauty and the Beast", 7.7999999999999998, new DateTime(2017, 3, 16, 21, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_movies_name",
                table: "movies",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
