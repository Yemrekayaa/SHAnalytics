using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_InGame_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Players_PlayerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TotalPlayed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Sessions",
                newName: "InGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_PlayerId",
                table: "Sessions",
                newName: "IX_Sessions_InGameId");

            migrationBuilder.AddColumn<string>(
                name: "DeathCause",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndCause",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectedHero",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalTime = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GameVersion = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InGames_PlayerId",
                table: "InGames",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_InGames_InGameId",
                table: "Sessions",
                column: "InGameId",
                principalTable: "InGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_InGames_InGameId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "InGames");

            migrationBuilder.DropColumn(
                name: "DeathCause",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "EndCause",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SelectedHero",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "InGameId",
                table: "Sessions",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_InGameId",
                table: "Sessions",
                newName: "IX_Sessions_PlayerId");

            migrationBuilder.AddColumn<int>(
                name: "TotalPlayed",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Players_PlayerId",
                table: "Sessions",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
