using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBug.Data.Migrations
{
    /// <inheritdoc />
    public partial class count : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Bugs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Bugs");
        }
    }
}
