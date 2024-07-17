using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class fixedfavoritesrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritePlayer",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "FavoriteTeam",
                table: "Favorites");

            migrationBuilder.CreateTable(
                name: "FavoritesFavorites",
                columns: table => new
                {
                    FavoritePlayerid = table.Column<int>(type: "int", nullable: false),
                    FavoriteTeamid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesFavorites", x => new { x.FavoritePlayerid, x.FavoriteTeamid });
                    table.ForeignKey(
                        name: "FK_FavoritesFavorites_Favorites_FavoritePlayerid",
                        column: x => x.FavoritePlayerid,
                        principalTable: "Favorites",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritesFavorites_Favorites_FavoriteTeamid",
                        column: x => x.FavoriteTeamid,
                        principalTable: "Favorites",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesFavorites_FavoriteTeamid",
                table: "FavoritesFavorites",
                column: "FavoriteTeamid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritesFavorites");

            migrationBuilder.AddColumn<string>(
                name: "FavoritePlayer",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FavoriteTeam",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
