using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealsPlace.Storage.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAndHorsepowerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Horsepower",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horsepower",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
