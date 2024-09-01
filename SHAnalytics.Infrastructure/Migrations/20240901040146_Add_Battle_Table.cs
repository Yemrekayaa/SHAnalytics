using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Battle_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BattleAreaId = table.Column<int>(type: "INTEGER", nullable: false),
                    BattleNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_BattleAreas_BattleAreaId",
                        column: x => x.BattleAreaId,
                        principalTable: "BattleAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_BattleAreaId",
                table: "Battles",
                column: "BattleAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");
        }
    }
}
