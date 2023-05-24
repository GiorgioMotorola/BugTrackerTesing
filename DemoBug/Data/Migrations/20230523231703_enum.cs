using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBug.Data.Migrations
{
    /// <inheritdoc />
    public partial class @enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "Bugs",
                newName: "severity");

            migrationBuilder.AlterColumn<int>(
                name: "severity",
                table: "Bugs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "severity",
                table: "Bugs",
                newName: "Severity");

            migrationBuilder.AlterColumn<string>(
                name: "Severity",
                table: "Bugs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
