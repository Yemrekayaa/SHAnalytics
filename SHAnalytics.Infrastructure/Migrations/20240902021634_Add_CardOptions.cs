using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_CardOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardOption_Battles_BattleId",
                table: "CardOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardOption",
                table: "CardOption");

            migrationBuilder.RenameTable(
                name: "CardOption",
                newName: "CardOptions");

            migrationBuilder.RenameIndex(
                name: "IX_CardOption_BattleId",
                table: "CardOptions",
                newName: "IX_CardOptions_BattleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardOptions",
                table: "CardOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardOptions_Battles_BattleId",
                table: "CardOptions",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardOptions_Battles_BattleId",
                table: "CardOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardOptions",
                table: "CardOptions");

            migrationBuilder.RenameTable(
                name: "CardOptions",
                newName: "CardOption");

            migrationBuilder.RenameIndex(
                name: "IX_CardOptions_BattleId",
                table: "CardOption",
                newName: "IX_CardOption_BattleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardOption",
                table: "CardOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardOption_Battles_BattleId",
                table: "CardOption",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
