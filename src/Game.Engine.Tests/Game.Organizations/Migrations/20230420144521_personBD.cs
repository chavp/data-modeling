using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Organizations.Migrations
{
    /// <inheritdoc />
    public partial class personBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                schema: "organization",
                table: "Parties",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                schema: "organization",
                table: "Parties");
        }
    }
}
