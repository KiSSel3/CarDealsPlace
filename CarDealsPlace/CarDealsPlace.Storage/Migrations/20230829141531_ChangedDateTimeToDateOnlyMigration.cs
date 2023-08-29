using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarDealsPlace.Storage.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateTimeToDateOnlyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ProductionYear",
                table: "Vehicles",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionYear",
                table: "Vehicles",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
