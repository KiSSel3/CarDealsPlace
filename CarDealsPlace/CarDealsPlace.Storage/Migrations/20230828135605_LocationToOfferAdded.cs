using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealsPlace.Storage.Migrations
{
    /// <inheritdoc />
    public partial class LocationToOfferAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Offers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Offers");
        }
    }
}
