using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueBud.Migrations
{
    /// <inheritdoc />
    public partial class mi21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ChargerLocation",
                newName: "ChargerType");

            migrationBuilder.AddColumn<string>(
                name: "ChargerName",
                table: "ChargerLocation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OccupationStatus",
                table: "ChargerLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChargerName",
                table: "ChargerLocation");

            migrationBuilder.DropColumn(
                name: "OccupationStatus",
                table: "ChargerLocation");

            migrationBuilder.RenameColumn(
                name: "ChargerType",
                table: "ChargerLocation",
                newName: "Address");
        }
    }
}
