using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Specification.Infrastructure.Implementation.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Directors_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "director_id",
                table: "movies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_directors", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("10b5cebc-ae88-478c-83a3-a103619ec51d"), "Marc Webb" },
                    { new Guid("33b8dc82-963b-44ea-915a-1322d565674e"), "Alex Kurtzman" },
                    { new Guid("8d422c65-ce51-4436-9d82-3e0a2185de93"), "M. Night Shyamalan" },
                    { new Guid("d9cff573-fcfc-4b2a-a84f-5aac5f04f8c8"), "Jon Favreau" },
                    { new Guid("edbfdab1-e053-40a4-b904-18d323879ca5"), "Chris Renaud" },
                    { new Guid("ee568809-eeb4-4391-ac0b-6bcc5abc06e0"), "Bill Condon" }
                });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("272b950e-6835-4865-a924-c09750723145"),
                column: "director_id",
                value: new Guid("10b5cebc-ae88-478c-83a3-a103619ec51d"));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("4c5979b4-73af-49dc-b6ea-b9eed4bdc5ca"),
                column: "director_id",
                value: new Guid("d9cff573-fcfc-4b2a-a84f-5aac5f04f8c8"));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("4f8eab4f-1eb6-49c3-9fca-f8cfb8cdc149"),
                column: "director_id",
                value: new Guid("edbfdab1-e053-40a4-b904-18d323879ca5"));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("6b125171-4cfc-4937-89cf-4b0d2384201d"),
                column: "director_id",
                value: new Guid("33b8dc82-963b-44ea-915a-1322d565674e"));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("7d5cbdb0-7068-4d75-8cdc-da5333cb446a"),
                column: "director_id",
                value: new Guid("8d422c65-ce51-4436-9d82-3e0a2185de93"));

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "id",
                keyValue: new Guid("ad4f3d9b-3d1a-43b7-b408-fdcf157125c2"),
                column: "director_id",
                value: new Guid("ee568809-eeb4-4391-ac0b-6bcc5abc06e0"));

            migrationBuilder.CreateIndex(
                name: "ix_movies_director_id",
                table: "movies",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "ix_directors_name",
                table: "directors",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_movies_directors_director_id",
                table: "movies",
                column: "director_id",
                principalTable: "directors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_movies_directors_director_id",
                table: "movies");

            migrationBuilder.DropTable(
                name: "directors");

            migrationBuilder.DropIndex(
                name: "ix_movies_director_id",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "director_id",
                table: "movies");
        }
    }
}
