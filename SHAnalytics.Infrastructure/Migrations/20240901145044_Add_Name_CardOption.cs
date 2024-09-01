using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHAnalytics.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Name_CardOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CardOption",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CardOption");
        }
    }
}
